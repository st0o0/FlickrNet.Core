﻿using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class PredicateTests
{
    [Fact]
    public void JsonStringToPredicates()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "predicates": {
                "page": "1",
                "pages": "1",
                "total": "3",
                "perpage": "500",
                "predicate": [
                  {
                    "usage": "20",
                    "namespaces": "1",
                    "_content": "elbow"
                  },
                  {
                    "usage": "52",
                    "namespaces": "2",
                    "_content": "face"
                  },
                  {
                    "usage": "10",
                    "namespaces": "1",
                    "_content": "hand"
                  }
                ]
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        using var sr = new StreamReader(ms);
        using var reader = new JsonTextReader(sr);

        var result = FlickrConvert.DeserializeObject<FlickrResult<Predicates>>(reader);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Predicates>(items);
        Assert.IsType<Predicate>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}