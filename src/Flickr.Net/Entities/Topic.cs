using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("topic")]
public record Topic : FlickrEntityBase, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("topic_id")]
    public string TopicId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string Iconserver { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public string Iconfarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

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
    [JsonPropertyName("role")]
    public MemberTypes Role { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("author_iconserver")]
    public string AuthorIconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("author_iconfarm")]
    public string AuthorIconFarm { get; set; }

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
    [JsonPropertyName("can_reply")]
    public bool CanReply { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_sticky")]
    public bool IsSticky { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_locked")]
    public bool IsLocked { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("datelastpost")]
    public DateTime LastPostDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("page")]
    public int Page { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }
}