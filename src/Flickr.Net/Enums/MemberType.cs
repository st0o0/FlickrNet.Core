namespace Flickr.Net.Enums;

/// <summary>
/// The type of a member. Passed as a parameter to <see
/// cref="IFlickrGroupsMembers.GetListAsync(string, MemberTypes, int, int, CancellationToken)"/> and
/// returned for each <see cref="Member"/> as well.
/// </summary>
[Flags]
public enum MemberTypes
{
    /// <summary>
    /// No member type has been specified (all should be returned).
    /// </summary>
    [EnumMember(Value = "")]
    None = 0,

    /// <summary>
    /// A basic member.
    /// </summary>
    [EnumMember(Value = "member")]
    Member = 1 << 0,

    /// <summary>
    /// A group moderator.
    /// </summary>
    [EnumMember(Value = "moderator")]
    Moderator = 1 << 1,

    /// <summary>
    /// A group adminstrator.
    /// </summary>
    [EnumMember(Value = "admin")]
    Admin = 1 << 2,

    /// <summary>
    /// Some strange kind of super-admin. Unsupported by the API.
    /// </summary>
    [EnumMember(Value = "narwhal")]
    Narwhal = 1 << 3,
}