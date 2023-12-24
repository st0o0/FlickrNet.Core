using Flickr.Net.Enums;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net.Test;

public class MemberTypeTests
{
    [Fact]
    public void MemberType_Admin_Has_Member()
    {
        var result = MemberTypes.Admin | MemberTypes.None;
        Assert.True(result.Is(MemberTypes.Admin));
        Assert.True(result.Has(MemberTypes.Admin));
        Assert.True(result.Has(MemberTypes.Member));
    }

    [Fact]
    public void MemberType_Admin_Has_Moderator()
    {
        const MemberTypes result = MemberTypes.Admin | MemberTypes.None;
        Assert.True(result.Is(MemberTypes.Admin));
        Assert.True(result.Has(MemberTypes.Admin));
        Assert.True(result.Has(MemberTypes.Moderator));
    }

    [Fact]
    public void MemberType_Moderator_Has_Member()
    {
        var result = MemberTypes.Moderator | MemberTypes.None;
        Assert.True(result.Is(MemberTypes.Moderator));
        Assert.True(result.Has(MemberTypes.Moderator));
        Assert.True(result.Has(MemberTypes.Member));
    }
}