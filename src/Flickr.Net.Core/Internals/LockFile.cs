using System.Diagnostics;

namespace Flickr.Net.Core.Internals;

/// <summary>
/// A non-reentrant mutex that is implemented using a lock file, and thus works across processes,
/// sessions, and machines (as long as the underlying FS provides robust r/w locking).
///
/// To use:
///
/// FileLock fLock = new FileLock(@"c:\foo\my.lock");
///
/// using (fLock.Acquire()) { // protected operations }
/// </summary>
internal class LockFile : IDisposable
{
    private readonly string filepath;
    private readonly DisposeHelper disposeHelper;
    private Stream stream;

    public LockFile(string filepath)
    {
        this.filepath = filepath;
        disposeHelper = new DisposeHelper(this);
    }

    public IDisposable Acquire()
    {
        var dir = Path.GetDirectoryName(filepath);

        lock (this)
        {
            while (stream != null)
            {
                Monitor.Wait(this);
            }

            while (true)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                try
                {
                    Debug.Assert(stream == null, "Stream was not null--programmer error");
                    stream = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                    return disposeHelper;
                }
                catch (IOException ioe)
                {
                    var errorCode = SafeNativeMethods.GetErrorCode(ioe);
                    switch (errorCode)
                    {
                        case 32:
                        case 33:
                        case 32 | 0x1620:
                        case 33 | 0x1620:
                            Thread.Sleep(50);
                            continue;
                        default:
                            throw;
                    }
                }
            }
        }
    }

    internal void Release()
    {
        lock (this)
        {
            // Doesn't hurt to pulse. Note that waiting threads will not actually continue to
            // execute until this critical section is exited.
            Monitor.PulseAll(this);

            if (stream == null)
            {
                throw new InvalidOperationException("Tried to dispose a FileLock that was not owned");
            }

            try
            {
                stream.Close();
                try
                {
                    File.Delete(filepath);
                }
                catch (IOException)
                {
                    // could fail if already acquired elsewhere
                }
            }
            finally
            {
                stream = null;
            }
        }
    }

    private class DisposeHelper : IDisposable
    {
        private readonly LockFile lockFile;

        public DisposeHelper(LockFile lockFile)
        {
            this.lockFile = lockFile;
        }

        public void Dispose()
        {
            lockFile.Release();
        }
    }

    public void Dispose()
    {
        if (disposeHelper != null)
        {
            disposeHelper.Dispose();
        }
        if (stream != null)
        {
            ((IDisposable)stream).Dispose();
        }
    }
}