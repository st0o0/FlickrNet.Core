namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
public static class MemberTypeExtensions
{
    /// <summary>
    /// Members the type to string.
    /// </summary>
    /// <param name="memberTypes">The member types.</param>
    /// <returns>A string.</returns>
    internal static string ToFlickrString(this MemberTypes memberTypes)
    {
        List<string> types = [];

        if (memberTypes.Has(MemberTypes.Narwhal))
        {
            types.Add("1");
        }

        if (memberTypes.Has(MemberTypes.Member))
        {
            types.Add("2");
        }

        if (memberTypes.Has(MemberTypes.Moderator))
        {
            types.Add("3");
        }

        if (memberTypes.Has(MemberTypes.Admin))
        {
            types.Add("4");
        }

        return string.Join(",", types.ToArray());
    }

    /// <summary>
    /// </summary>
    public static bool Has(this MemberTypes type, in MemberTypes value)
    {
        return value <= type;
    }

    /// <summary>
    /// </summary>
    public static bool Is(this MemberTypes type, MemberTypes value)
    {
        return type == value;
    }

    /// <summary>
    /// </summary>
    public static MemberTypes Add(this MemberTypes type, MemberTypes value)
    {
        return type | value;
    }

    /// <summary>
    /// </summary>
    public static MemberTypes Remove(this MemberTypes type, MemberTypes value)
    {
        return type & ~value;
    }
}