using ButterflyXp.Core.Models;

namespace ButterflyXp.Tests;

public class ButterflyTests
{
    private static Butterfly CreateButterfly() => new("Flora");

    [Fact]
    public void NewButterfly_StartsAtLevel1With0Xp()
    {
        var butterfly = CreateButterfly();

        Assert.Equal(0, butterfly.Xp);
        Assert.Equal(1, butterfly.Level);
    }

    [Fact]
    public void AddXp_IncreasesXp()
    {
        var butterfly = CreateButterfly();

        butterfly.AddXp(5);

        Assert.Equal(5, butterfly.Xp);
    }
}