using Flickr.Net.Core.SearchOptions;

namespace Flickr.Net.Core.Enums;

/// <summary>
/// The sort order for the <see cref="IFlickrPhotos.SearchAsync(PhotoSearchOptions, CancellationToken)"/>, <see
/// cref="IFlickrPhotos.GetWithGeoDataAsync(PartialSearchOptions, CancellationToken)"/>, <see cref="IFlickrPhotos.GetWithoutGeoDataAsync(PartialSearchOptions, CancellationToken)"/> methods.
/// </summary>
[Serializable]
public enum PhotoSearchSortOrder
{
    /// <summary>
    /// No sort order.
    /// </summary>
    None,

    /// <summary>
    /// Sort by date uploaded (posted).
    /// </summary>
    DatePostedAscending,

    /// <summary>
    /// Sort by date uploaded (posted) in descending order.
    /// </summary>
    DatePostedDescending,

    /// <summary>
    /// Sort by date taken.
    /// </summary>
    DateTakenAscending,

    /// <summary>
    /// Sort by date taken in descending order.
    /// </summary>
    DateTakenDescending,

    /// <summary>
    /// Sort by interestingness (least interesting first)
    /// </summary>
    InterestingnessAscending,

    /// <summary>
    /// Sort by interestingness in descending order (i.e. most interesting first)
    /// </summary>
    InterestingnessDescending,

    /// <summary>
    /// Sort by relevance (only applicable to text searches)
    /// </summary>
    Relevance
}