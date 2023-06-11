﻿namespace Flickr.Net.Core.Enums;

/// <summary>
/// Used by <see cref="IFlickrPlaces.PlacesForUserAsync(PlaceType, string, string, int, DateTime?, DateTime?, DateTime?, DateTime?, CancellationToken)"/>.
/// </summary>
public enum PlaceType
{
    /// <summary>
    /// No place type selected. Not used by the Flickr API.
    /// </summary>
    None = 0,

    /// <summary>
    /// Locality.
    /// </summary>
    Locality = 7,

    /// <summary>
    /// County.
    /// </summary>
    County = 9,

    /// <summary>
    /// Region.
    /// </summary>
    Region = 8,

    /// <summary>
    /// Country.
    /// </summary>
    Country = 12,

    /// <summary>
    /// Neighbourhood.
    /// </summary>
    Neighbourhood = 22,

    /// <summary>
    /// Continent.
    /// </summary>
    Continent = 29
}