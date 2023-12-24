using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Reply : FlickrEntityBase<Id>, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("author")]
    public string Author { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("authorname")]
    public string AuthorName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_pro")]
    public bool IsPro { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("role")]
    public MemberTypes Role { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("can_edit")]
    public bool CanEdit { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("can_delete")]
    public bool CanDelete { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("lastedit")]
    public DateTime LastEdit { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("message")]
    public List<string> Messages { get; set; }
}