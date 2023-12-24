using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

    /// <summary>
    /// </summary>
public record Member : FlickrEntityBase<NsId>, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public string IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("membertype")]
    public MemberTypes Type { get; set; }
}