using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGroupsMembers
{
    async Task<Members> IFlickrGroupsMembers.GetListAsync(string groupId, MemberTypes memberTypes, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.members.getList" },
            {"group_id", groupId }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("membertypes", memberTypes, x => x != MemberTypes.None, x => x.ToFlickrString());

        return await GetResponseAsync<Members>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr groups members.
/// </summary>
public interface IFlickrGroupsMembers
{
    /// <summary>
    /// Get a list of the members of a group.
    /// </summary>
    /// <remarks>
    /// The call must be signed on behalf of a Flickr member, and the ability to see the group
    /// membership will be determined by the Flickr member's group privileges.
    /// </remarks>
    /// <param name="groupId">
    /// Return a list of members for this group. The group must be viewable by the Flickr member on
    /// whose behalf the API call is made.
    /// </param>
    /// <param name="memberTypes">The types of members to be returned. Can be more than one.</param>
    /// <param name="page">The page of the results to return (default is 1).</param>
    /// <param name="perPage">
    /// The number of members to return per page (default is 100, max is 500).
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Members> GetListAsync(string groupId, MemberTypes memberTypes = MemberTypes.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}