using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Flickr.Net.Internals;

/// <summary>
/// Internal class providing certain utility functions to other classes.
/// </summary>
public static class UtilityMethods
{
    private static readonly DateTime UnixStartDate = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private const string PhotoUrlFormat = "https://farm{0}.staticflickr.com/{1}/{2}_{3}{4}.{5}";
    private static readonly char[] separator = ['='];

    /// <summary>
    /// Encodes a URL quesrystring data component.
    /// </summary>
    /// <param name="data">The data to encode.</param>
    /// <returns>The URL encoded string.</returns>
    public static string UrlEncode(string data)
    {
        return Uri.EscapeDataString(data);
    }

    /// <summary>
    /// Converts a <see cref="DateTime"/> object into a unix timestamp number.
    /// </summary>
    /// <param name="date">The date to convert.</param>
    /// <returns>A long for the number of seconds since 1st January 1970, as per unix specification.</returns>
    public static string DateToUnixTimestamp(DateTime date)
    {
        var ts = date - UnixStartDate;
        return ts.TotalSeconds.ToString("0", System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    /// <summary>
    /// Converts a string, representing a unix timestamp number into a <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="timestamp">The timestamp, as a string.</param>
    /// <returns>The <see cref="DateTime"/> object the time represents.</returns>
    public static DateTime UnixTimestampToDate(string timestamp)
    {
        if (string.IsNullOrEmpty(timestamp))
        {
            return DateTime.MinValue;
        }

        try
        {
            return UnixTimestampToDate(long.Parse(timestamp, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo));
        }
        catch (FormatException)
        {
            return DateTime.MinValue;
        }
    }

    /// <summary>
    /// Converts a <see cref="long"/>, representing a unix timestamp number into a <see
    /// cref="DateTime"/> object.
    /// </summary>
    /// <param name="timestamp">The unix timestamp.</param>
    /// <returns>The <see cref="DateTime"/> object the time represents.</returns>
    public static DateTime UnixTimestampToDate(long timestamp)
    {
        return UnixStartDate.AddSeconds(timestamp);
    }

    internal static void WriteInt32(Stream s, int i)
    {
        s.WriteByte((byte)(i & 0xFF));
        s.WriteByte((byte)(i >> 8 & 0xFF));
        s.WriteByte((byte)(i >> 16 & 0xFF));
        s.WriteByte((byte)(i >> 24 & 0xFF));
    }

    internal static void WriteString(Stream s, string str)
    {
        WriteInt32(s, str.Length);
        foreach (var c in str)
        {
            s.WriteByte((byte)(c & 0xFF));
            s.WriteByte((byte)(c >> 8 & 0xFF));
        }
    }

    internal static void WriteByteArray(Stream stream, byte[] value)
    {
        WriteString(stream, Encoding.UTF8.GetString(value));
    }

    internal static int ReadInt32(Stream s)
    {
        int i = 0, b;
        for (var j = 0; j < 4; j++)
        {
            b = s.ReadByte();
            if (b == -1)
            {
                throw new IOException("Unexpected EOF encountered");
            }

            i |= b << j * 8;
        }
        return i;
    }

    internal static string ReadString(Stream s)
    {
        var len = ReadInt32(s);
        var chars = new char[len];
        for (var i = 0; i < len; i++)
        {
            int hi, lo;
            lo = s.ReadByte();
            hi = s.ReadByte();
            if (lo == -1 || hi == -1)
            {
                throw new IOException("Unexpected EOF encountered");
            }

            chars[i] = (char)(lo | hi << 8);
        }
        return new string(chars);
    }

    internal static byte[] ReadByteArray(Stream s)
    {
        using var ms = new MemoryStream();
        s.CopyTo(ms);
        return ms.ToArray();
    }


    /// <summary>
    /// Urls the format.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <param name="size">The size.</param>
    /// <param name="extension">The extension.</param>
    /// <returns>A string.</returns>
    public static string UrlFormat(Photo p, SizeType size, string extension) => UrlFormat(p.Farm, p.Server, p.Id, p.Secret, size, extension);

    /// <summary>
    /// Urls the format.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <param name="size">The size.</param>
    /// <param name="extension">The extension.</param>
    /// <returns>A string.</returns>
    public static string UrlFormat(PhotoInfo p, SizeType size, string extension)
    {
        if (size == SizeType.Original)
        {
            return UrlFormat(p.Farm, p.Server, p.Id, p.OriginalSecret, size, extension);
        }
        else
        {
            return UrlFormat(p.Farm, p.Server, p.Id, p.Secret, size, extension);
        }
    }

    /// <summary>
    /// </summary>
    public static string UrlFormat(Photoset p, SizeType size, string extension)
    {
        return UrlFormat(p.Farm, p.Server, p.Primary, p.Secret, size, extension);
    }

    /// <summary>
    /// Urls the format.
    /// </summary>
    /// <param name="farm">The farm.</param>
    /// <param name="server">The server.</param>
    /// <param name="photoId">The photoid.</param>
    /// <param name="secret">The secret.</param>
    /// <param name="size">The size.</param>
    /// <param name="extension">The extension.</param>
    /// <returns>A string.</returns>
    public static string UrlFormat(int farm, string server, string photoId, string secret, SizeType size, string extension)
    {
        var sizeAbbreviation = size.GetEnumMemberValue();

        return UrlFormat(PhotoUrlFormat, farm, server, photoId, secret, sizeAbbreviation, extension);
    }

    private static string UrlFormat(string format, params object[] parameters)
    {
        return string.Format(System.Globalization.CultureInfo.InvariantCulture, format, parameters);
    }

    /// <summary>
    /// Parses the id to member type.
    /// </summary>
    /// <param name="memberTypeId">The member type id.</param>
    /// <returns>A MemberTypes.</returns>
    public static MemberTypes ParseIdToMemberType(string memberTypeId)
    {
        return memberTypeId switch
        {
            "1" => MemberTypes.Narwhal,
            "2" => MemberTypes.Member,
            "3" => MemberTypes.Moderator,
            "4" => MemberTypes.Admin,
            _ => MemberTypes.None,
        };
    }

    internal static MemberTypes ParseRoleToMemberType(string memberRole)
    {
        return memberRole switch
        {
            "admin" => MemberTypes.Admin,
            "moderator" => MemberTypes.Moderator,
            "member" => MemberTypes.Member,
            _ => MemberTypes.None,
        };
    }

    /// <summary>
    /// Generates an MD5 Hash of the passed in string.
    /// </summary>
    /// <param name="data">The unhashed string.</param>
    /// <returns>The MD5 hash string.</returns>
    public static string MD5Hash(string data)
    {
        byte[] hashedBytes;

        using (var md5 = MD5.Create())
        {
            var bytes = Encoding.UTF8.GetBytes(data);
            hashedBytes = md5.ComputeHash(bytes, 0, bytes.Length);
        }
        return BitConverter.ToString(hashedBytes).Replace("-", string.Empty).ToLower();
    }

    /// <summary>
    /// Mies the sql to date.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <returns>A DateTime.</returns>
    public static DateTime MySqlToDate(string p)
    {
        var format1 = "yyyy-MM-dd";
        var format2 = "yyyy-MM-dd hh:mm:ss";
        var iformat = System.Globalization.DateTimeFormatInfo.InvariantInfo;

        try
        {
            return DateTime.ParseExact(p, format1, iformat, System.Globalization.DateTimeStyles.None);
        }
        catch (FormatException)
        {
        }

        try
        {
            return DateTime.ParseExact(p, format2, iformat, System.Globalization.DateTimeStyles.None);
        }
        catch (FormatException)
        {
        }

        return DateTime.MinValue;
    }

    /// <summary>
    /// Parses a date which may contain only a vald year component.
    /// </summary>
    /// <param name="date">The date, as a string, to be parsed.</param>
    /// <returns>The parsed <see cref="DateTime"/>.</returns>
    public static DateTime ParseDateWithGranularity(string date)
    {
        var output = DateTime.MinValue;

        if (string.IsNullOrEmpty(date))
        {
            return output;
        }

        if (date == "0000-00-00 00:00:00")
        {
            return output;
        }

        if (date.EndsWith("-00-01 00:00:00", StringComparison.Ordinal))
        {
            output = new DateTime(int.Parse(date.Substring(0, 4), System.Globalization.NumberFormatInfo.InvariantInfo), 1, 1);
            return output;
        }

        var format = "yyyy-MM-dd HH:mm:ss";
        try
        {
            output = DateTime.ParseExact(date, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
        }
        catch (FormatException)
        {
#if DEBUG
            throw;
#endif
        }
        return output;
    }

    /// <summary>
    /// Returns the buddy icon for a given set of server, farm and userid. If no server is present
    /// then returns the standard buddy icon.
    /// </summary>
    /// <param name="server"></param>
    /// <param name="farm"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string BuddyIcon(string server, string farm, string userId)
    {
        if (string.IsNullOrEmpty(server) || server == "0")
        {
            return "https://www.flickr.com/images/buddyicon.jpg";
        }
        else
        {
            return string.Format(System.Globalization.CultureInfo.InvariantCulture, "https://farm{0}.staticflickr.com/{1}/buddyicons/{2}.jpg", farm, server, userId);
        }
    }

    /// <summary>
    /// Converts a URL parameter encoded string into a dictionary.
    /// </summary>
    /// <remarks>
    /// e.g. ab=cd&amp;ef=gh will return a dictionary of { "ab" =&gt; "cd", "ef" =&gt; "gh" }.
    /// </remarks>
    /// <param name="response"></param>
    /// <returns></returns>
    public static Dictionary<string, string> StringToDictionary(string response)
    {
        Dictionary<string, string> dic = [];

        if (string.IsNullOrEmpty(response))
        {
            return dic;
        }

        var parts = response.Split('&');

        foreach (var part in parts)
        {
            var bits = part.Split(separator, 2, StringSplitOptions.RemoveEmptyEntries);
            dic.Add(bits[0], bits.Length == 1 ? "" : Uri.UnescapeDataString(bits[1]));
        }

        return dic;
    }

    /// <summary>
    /// Escapes a string for use with OAuth.
    /// </summary>
    /// <remarks>
    /// The only valid characters are Alphanumerics and "-", "_", "." and "~". Everything else is
    /// hex encoded.
    /// </remarks>
    /// <param name="text">The text to escape.</param>
    /// <returns>The escaped string.</returns>
    public static string EscapeOAuthString(string text)
    {
        var value = text;

        value = EscapeDataString(value).Replace("+", "%20");

        // UrlEncode escapes with lowercase characters (e.g. %2f) but oAuth needs %2F
        value = Regex.Replace(value, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper());

        // these characters are not escaped by UrlEncode() but needed to be escaped
        value = value.Replace("(", "%28").Replace(")", "%29").Replace("$", "%24").Replace("!", "%21").Replace(
            "*", "%2A").Replace("'", "%27");

        // these characters are escaped by UrlEncode() but will fail if unescaped!
        value = value.Replace("%7E", "~");

        return value;
    }

    /// <summary>
    /// Cleans the collection id.
    /// </summary>
    /// <param name="collectionId">The collection id.</param>
    /// <returns>A string.</returns>
    public static string CleanCollectionId(string collectionId)
    {
        return collectionId.IndexOf('-') < 0
                   ? collectionId
                   : collectionId[(collectionId.IndexOf('-') + 1)..];
    }

    internal static string EscapeDataString(string value)
    {
        var limit = 2000;
        StringBuilder sb = new(value.Length + value.Length / 2);
        var loops = value.Length / limit;

        for (var i = 0; i <= loops; i++)
        {
            if (i < loops)
            {
                sb.Append(Uri.EscapeDataString(value.Substring(limit * i, limit)));
            }
            else
            {
                sb.Append(Uri.EscapeDataString(value[(limit * i)..]));
            }
        }

        return sb.ToString();
    }
}