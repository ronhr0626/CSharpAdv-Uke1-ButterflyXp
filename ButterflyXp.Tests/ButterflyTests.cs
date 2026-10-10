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
       [Fact]
    public void AddXp_IncreasesXp()
    {
        var butterfly = new Butterfly("Flora");

        butterfly.AddXp(5);

        Assert.Equal(5, butterfly.Xp);
    }
}