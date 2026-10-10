using ButterflyXp.Core.Models;

namespace ButterflyXp.Tests;

public class ButterflyTests
{
    [Fact]
    public void NewButterfly_StartsAtLevel1With0Xp()
    {
        var butterfly = new Butterfly("Flora");

        Assert.Equal(0, butterfly.Xp);
        Assert.Equal(1, butterfly.Level);
    }
}