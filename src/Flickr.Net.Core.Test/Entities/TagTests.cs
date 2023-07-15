﻿using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class TagTests
{
    [Fact]
    public void JsonStringToTag()
    {
        var json = /*lang=json,strict*/ """
            {
                "tags": {
                    "source": "foo",
                    "tag": [
                        {
                            "_content": "fighters"
                        },
                        {
                            "_content": "dave"
                        },
                        {
                            "_content": "grohl"
                        },
                        {
                            "_content": "concert"
                        },
                        {
                            "_content": "music"
                        },
                        {
                            "_content": "live"
                        },
                        {
                            "_content": "foofighters"
                        },
                        {
                            "_content": "rock"
                        },
                        {
                            "_content": "davegrohl"
                        },
                        {
                            "_content": "taylor"
                        },
                        {
                            "_content": "band"
                        },
                        {
                            "_content": "dog"
                        },
                        {
                            "_content": "hawkins"
                        },
                        {
                            "_content": "gig"
                        },
                        {
                            "_content": "festival"
                        },
                        {
                            "_content": "nirvana"
                        },
                        {
                            "_content": "chris"
                        },
                        {
                            "_content": "nate"
                        },
                        {
                            "_content": "lion"
                        },
                        {
                            "_content": "wembley"
                        },
                        {
                            "_content": "guitar"
                        },
                        {
                            "_content": "stadium"
                        },
                        {
                            "_content": "serj"
                        },
                        {
                            "_content": "tankian"
                        },
                        {
                            "_content": "arena"
                        },
                        {
                            "_content": "fu"
                        },
                        {
                            "_content": "london"
                        },
                        {
                            "_content": "chinese"
                        },
                        {
                            "_content": "show"
                        },
                        {
                            "_content": "mendel"
                        },
                        {
                            "_content": "silence"
                        },
                        {
                            "_content": "echoes"
                        },
                        {
                            "_content": "tattoo"
                        },
                        {
                            "_content": "japanese"
                        },
                        {
                            "_content": "portrait"
                        },
                        {
                            "_content": "crowd"
                        },
                        {
                            "_content": "park"
                        },
                        {
                            "_content": "david"
                        },
                        {
                            "_content": "canon"
                        },
                        {
                            "_content": "stage"
                        },
                        {
                            "_content": "love"
                        },
                        {
                            "_content": "manchester"
                        },
                        {
                            "_content": "light"
                        },
                        {
                            "_content": "foodog"
                        },
                        {
                            "_content": "asian"
                        },
                        {
                            "_content": "green"
                        },
                        {
                            "_content": "uk"
                        },
                        {
                            "_content": "girl"
                        },
                        {
                            "_content": "yong"
                        },
                        {
                            "_content": "tau"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        using var sr = new StreamReader(ms);
        using var reader = new JsonTextReader(sr);

        var result = FlickrConvert.DeserializeObject<FlickrResult<Tags>>(reader);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Tags>(items);
        Assert.NotEmpty(items.Values);
    }
}
