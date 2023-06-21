﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flickr.Net.Core.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum UrlType
{
    [EnumMember(Value = "none")]
    None,

    [EnumMember(Value = "site")]
    Site,

    [EnumMember(Value = "license")]
    License,

    [EnumMember(Value = "flickr")]
    Flickr
}