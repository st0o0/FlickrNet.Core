﻿namespace Flickr.Net.Core.Enums;

/// <summary>
/// The contact type.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ContactType
{
    /// <summary>
    /// TBD
    /// </summary>
    [EnumMember(Value = "none")]
    None,

    /// <summary>
    /// TBD
    /// </summary>
    [EnumMember(Value = "friends")]
    Friends,

    /// <summary>
    /// TBD
    /// </summary>
    [EnumMember(Value = "family")]
    Famliy,

    /// <summary>
    /// TBD
    /// </summary>
    [EnumMember(Value = "both")]
    Both,

    /// <summary>
    /// TBD
    /// </summary>
    [EnumMember(Value = "neither")]
    Neither
}