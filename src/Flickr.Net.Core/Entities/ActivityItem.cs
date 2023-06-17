//namespace Flickr.Net.Core.Entities;

///// <summary>
///// Activity class used for <see cref="IFlickrActivity.UserPhotosAsync(int, TimeType, int, int,
///// CancellationToken)"/> and <see cref="IFlickrActivity.UserCommentsAsync(int, int, CancellationToken)"/>.
///// </summary>
//public sealed class ActivityItem : IFlickrParsable
//{
//    /// <summary>
//    /// Default constructor.
//    /// </summary>
//    public ActivityItem()
//    {
//        Events = new Collection<ActivityEvent>();
//    }

// ///
// <summary>
// /// The <see cref="Enums.ItemType"/> of the item. ///
// </summary>
// public ItemType ItemType { get; set; }

// ///
// <summary>
// /// The ID of either the photoset or the photo. ///
// </summary>
// public string Id { get; set; }

// ///
// <summary>
// /// The secret for either the photo, or the primary photo for the photoset. ///
// </summary>
// public string Secret { get; set; }

// ///
// <summary>
// /// The server for either the photo, or the primary photo for the photoset. ///
// </summary>
// public string Server { get; set; }

// ///
// <summary>
// /// The server farm for either the photo, or the primary photo for the photoset. ///
// </summary>
// public string Farm { get; set; }

// ///
// <summary>
// /// The title of the photoset or photo. ///
// </summary>
// public string Title { get; set; }

// ///
// <summary>
// /// The number of new comments within the given time frame. ///
// </summary>
// ///
// <remarks>
// /// Only applicable for <see cref="IFlickrActivity.UserPhotosAsync(int, TimeType, int, int,
// CancellationToken)"/>. ///
// </remarks>
// public int NewComments { get; set; }

// ///
// <summary>
// /// The number of old comments within the given time frame. ///
// </summary>
// ///
// <remarks>
// /// Only applicable for <see cref="IFlickrActivity.UserPhotosAsync(int, TimeType, int, int,
// CancellationToken)"/>. ///
// </remarks>
// public int OldComments { get; set; }

// ///
// <summary>
// /// The number of comments on the item. ///
// </summary>
// ///
// <remarks>Only applicable for <see cref="IFlickrActivity.UserCommentsAsync(int, int, CancellationToken)"/>.</remarks>
// public int Comments { get; set; }

// ///
// <summary>
// /// Gets the number of views for this photo or photoset. ///
// </summary>
// public int Views { get; set; }

// ///
// <summary>
// /// You want more! You got it! ///
// </summary>
// ///
// <remarks>Actually, not sure what this it for!</remarks>
// public bool More { get; set; }

// ///
// <summary>
// /// The user id of the owner of this item. ///
// </summary>
// public string OwnerId { get; set; }

// ///
// <summary>
// /// The real name of the activity item owner. ///
// </summary>
// public string RealName { get; set; }

// ///
// <summary>
// /// The username of the owner of this item. ///
// </summary>
// public string OwnerName { get; set; }

// ///
// <summary>
// /// The web server number for the activity item owners buddy icon. ///
// </summary>
// public string OwnerServer { get; set; }

// ///
// <summary>
// /// The server farm number for the activity item owners buddy icon. ///
// </summary>
// public string OwnerFarm { get; set; }

// ///
// <summary>
// /// The activity item owners buddy icon. ///
// </summary>
// public string OwnerBuddyIcon =&gt; UtilityMethods.BuddyIcon(OwnerServer, OwnerFarm, OwnerId);

// ///
// <summary>
// /// If the type is a photoset then this contains the number of photos in the set. Otherwise ///
// returns -1. ///
// </summary>
// public int? Photos { get; set; }

// ///
// <summary>
// /// If this is a photoset then returns the primary photo id, otherwise will be null ( ///
// <code>Nothing</code>
// /// in VB.Net). ///
// </summary>
// public string PrimaryPhotoId { get; set; }

// ///
// <summary>
// /// The number of new notes within the given time frame. ///
// </summary>
// ///
// <remarks>
// /// Only applicable for photos and when calling <see cref="IFlickrActivity.UserPhotosAsync(int,
// /// TimeType, int, int, CancellationToken)"/>. ///
// </remarks>
// public int? NewNotes { get; set; }

// ///
// <summary>
// /// The number of old notes within the given time frame. ///
// </summary>
// ///
// <remarks>
// /// Only applicable for photos and when calling <see cref="IFlickrActivity.UserPhotosAsync(int,
// /// TimeType, int, int, CancellationToken)"/>. ///
// </remarks>
// public int? OldNotes { get; set; }

// /// <summary> /// The number of comments on the photo. /// </summary> /// <remarks> /// Only
// applicable for photos and when calling <see /// cref="IFlickrActivity.UserCommentsAsync(int, int,
// CancellationToken)"/>. /// </remarks> public int? Notes { get; set; }

// ///
// <summary>
// /// If the type is a photo then this contains the number of favourites in the set. Otherwise ///
// returns -1. ///
// </summary>
// public int? Favorites { get; set; }

// ///
// <summary>
// /// The media type for this activity item, either photo or video. ///
// </summary>
// public MediaType Media { get; set; }

// /// <summary> /// The events that comprise this activity item. /// </summary> public
// Collection<ActivityEvent> Events { get; set; }

// ///
// <summary>
// /// The URL for the square thumbnail of a photo or the primary photo for a photoset or gallery. ///
// </summary>
// public string SquareThumbnailUrl { get { if (ItemType == ItemType.Photo) { return
// UtilityMethods.UrlFormat(Farm, Server, Id, Secret, "_s", "jpg"); } if (ItemType ==
// ItemType.Photoset || ItemType == ItemType.Gallery) { return UtilityMethods.UrlFormat(Farm,
// Server, PrimaryPhotoId, Secret, "_s", "jpg"); } return null; } }

// ///
// <summary>
// /// The URL for the small thumbnail of a photo or the primary photo for a photoset or gallery. ///
// </summary>
// public string SmallUrl { get { if (ItemType == ItemType.Photo) { return
// UtilityMethods.UrlFormat(Farm, Server, Id, Secret, "_m", "jpg"); } if (ItemType ==
// ItemType.Photoset || ItemType == ItemType.Gallery) { return UtilityMethods.UrlFormat(Farm,
// Server, PrimaryPhotoId, Secret, "_m", "jpg"); } return null; } }

// void IFlickrParsable.Load(XmlReader reader) { LoadAttributes(reader);

// LoadElements(reader); }

// private void LoadElements(XmlReader reader) { while (reader.LocalName != "item") { switch
// (reader.LocalName) { case "title": Title = reader.ReadElementContentAsString(); break;

// case "activity": reader.ReadToDescendant("event"); while (reader.LocalName == "event") {
// ActivityEvent e = new(); ((IFlickrParsable)e).Load(reader); Events.Add(e); } reader.Read(); break;

// default: UtilityMethods.CheckParsingException(reader); reader.Skip(); break; } }

// reader.Read(); }

// private void LoadAttributes(XmlReader reader) { while (reader.MoveToNextAttribute()) { switch
// (reader.LocalName) { case "type": ItemType = reader.Value switch { "photoset" =>
// ItemType.Photoset, "photo" => ItemType.Photo, "gallery" => ItemType.Gallery, _ =>
// ItemType.Unknown, }; break;

// case "media": Media = reader.Value switch { "photo" => MediaType.Photos, "video" =>
// MediaType.Videos, _ => MediaType.None, }; break;

// case "owner": OwnerId = reader.Value; break;

// case "ownername": OwnerName = reader.Value; break;

// case "id": Id = reader.Value; break;

// case "secret": Secret = reader.Value; break;

// case "server": Server = reader.Value; break;

// case "farm": Farm = reader.Value; break;

// case "iconserver": OwnerServer = reader.Value; break;

// case "iconfarm": OwnerFarm = reader.Value; break;

// case "commentsnew": NewComments = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "commentsold": OldComments = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "comments": Comments = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "views": Views = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "photos": Photos = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "more": More = reader.Value == "0"; break;

// case "primary": PrimaryPhotoId = reader.Value; break;

// case "notesnew": NewNotes = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "notesold": OldNotes = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "notes": Notes = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "faves": Favorites = int.Parse(reader.Value,
// System.Globalization.NumberFormatInfo.InvariantInfo); break;

// case "realname": RealName = reader.Value; break;

// default: UtilityMethods.CheckParsingException(reader); break; } }

//        reader.Read();
//    }
//}