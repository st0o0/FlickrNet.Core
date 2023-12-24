using System.Text;
using Flickr.Net.Enums;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class ReplyTests
{
  [Fact]
  public void JsonStringToReply()
  {
    var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "reply": {
                "id": "72157607082559968",
                "author": "30134652@N05",
                "authorname": "JAMAL'S ACCOUNT",
                "is_pro": "0",
                "role": "admin",
                "iconserver": "0",
                "iconfarm": "0",
                "can_edit": "1",
                "can_delete": "1",
                "datecreate": "1337975921",
                "lastedit": "0",
                "message": [
                  "...well, too bad.",
                  "...well, too bad."
                ]
              }
            }
            """;

    var result = FlickrConvert.DeserializeObject<FlickrResult<Reply>>(Encoding.UTF8.GetBytes(json));

    Assert.NotNull(result);
    Assert.False(result.HasError);
    var items = result.Content;
    Assert.IsType<Reply>(items);
    Assert.IsType<MemberTypes>(items.Role);
    Assert.Equal(MemberTypes.Admin, items.Role);
    Assert.False(items.IsPro);
    Assert.True(items.CanEdit);
    Assert.True(items.CanDelete);
  }

  [Fact]
  public void JsonStringToReplies()
  {
    var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "replies": {
                "topic": {
                  "topic_id": "72157625038324579",
                  "subject": "A long time ago in a galaxy far, far away...",
                  "group_id": "46744914@N00",
                  "iconserver": "1",
                  "iconfarm": "1",
                  "name": "Tell a story in 5 frames (Visual story telling)",
                  "author": "53930889@N04",
                  "authorname": "Smallportfolio_jm08",
                  "role": "member",
                  "author_iconserver": "5169",
                  "author_iconfarm": "6",
                  "can_edit": "0",
                  "can_delete": "0",
                  "can_reply": "0",
                  "is_sticky": "0",
                  "is_locked": "",
                  "datecreate": "1287070965",
                  "datelastpost": "1336905518",
                  "total": "8",
                  "page": "1",
                  "per_page": "3",
                  "pages": "2",
                  "message": "<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5080874079/\" title=\"Star Wars 1 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4035/5080874079_684cf874e0_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 1 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467846/\" title=\"Star Wars 2 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4071/5081467846_2eec86176d_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 2 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467886/\" title=\"Star Wars 3 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4021/5081467886_d8cca6c8e8_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 3 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467910/\" title=\"Star Wars 4 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4084/5081467910_274bb11fdc_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 4 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467948/\" title=\"Star Wars 5 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4154/5081467948_1a5f200bc0_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 5 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>",
                },
                "reply": [
                  {
                    "id": "72157625163054214",
                    "author": "41380738@N05",
                    "authorname": "BlueRidgeKitties",
                    "role": "member",
                    "iconserver": "2459",
                    "iconfarm": "3",
                    "can_edit": "0",
                    "can_delete": "0",
                    "datecreate": "1287071539",
                    "lastedit": "0",
                    "message": [
                      "*LOL* The universe is full of <a href=\"http://www.flickr.com/groups/visualstory/discuss/72157622533160886/\">giant furry space monsters<\/a> it seems! Love it.",
                      "On a scale of 1 to 10 of awesome. This is a 15"
                    ]
                  },
                  {
                    "id": "72157625163539300",
                    "author": "52101018@N00",
                    "authorname": "pterandon",
                    "role": "admin",
                    "iconserver": "1",
                    "iconfarm": "1",
                    "can_edit": "0",
                    "can_delete": "0",
                    "datecreate": "1287076748",
                    "lastedit": "0",
                    "message": [
                      "Great work. Good focus on different aspects of scene in each frame.  Funny ending-- even better that I didn't notice the cat right away!  Being a hopeless Trekkie, I was wondering why Han was doing the Vulcan death grip on one of his allies....",
                      "On a scale of 1 to 10 of awesome. This is a 15"
                    ]
                  },
                  {
                    "id": "72157625040116805",
                    "author": "54830408@N02",
                    "authorname": "tay.grisham",
                    "role": "member",
                    "iconserver": "0",
                    "iconfarm": "0",
                    "can_edit": "0",
                    "can_delete": "0",
                    "datecreate": "1287089858",
                    "lastedit": "0",
                    "message": [
                      "On a scale of 1 to 10 of awesome. This is a 15",
                      "On a scale of 1 to 10 of awesome. This is a 15"
                    ]
                  }
                ]
              }
            }
            """;

    var result = FlickrConvert.DeserializeObject<FlickrResult<Replies>>(Encoding.UTF8.GetBytes(json));

    Assert.NotNull(result);
    Assert.False(result.HasError);
    var items = result.Content;
    Assert.IsType<Topic>(items.Topic);
    Assert.Equal(8, items.Topic.Total);
    Assert.False(items.Topic.IsSticky);
    Assert.False(items.Topic.IsLocked);
    Assert.False(items.Topic.CanReply);
    Assert.False(items.Topic.CanDelete);
    Assert.False(items.Topic.CanEdit);
    Assert.IsType<Reply>(items.Values[0]);
    Assert.IsType<MemberTypes>(items.Values[0].Role);
    Assert.Equal(MemberTypes.Member, items.Values[0].Role);
  }
}