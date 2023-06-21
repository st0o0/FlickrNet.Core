﻿using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PandaPhoto : ExtendedPhotoBase
{
    [JsonProperty("ownername")]
    public string OwnerName { get; set; }
}