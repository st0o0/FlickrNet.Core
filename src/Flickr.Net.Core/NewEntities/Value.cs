﻿using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Value
{
    [JsonProperty("usage")]
    public string Usage { get; set; }

    [JsonProperty("namespace")]
    public string Namespace { get; set; }

    [JsonProperty("predicate")]
    public string Predicate { get; set; }

    [JsonProperty("first_added")]
    [JsonConverter(typeof(TimestampToDateTimeConverter))]
    public DateTime FirstAdded { get; set; }

    [JsonProperty("last_added")]
    [JsonConverter(typeof(TimestampToDateTimeConverter))]
    public DateTime LastAdded { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}