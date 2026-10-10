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

    [Theory]
    [InlineData(9, 1)]
    [InlineData(10, 2)]
    [InlineData(20, 3)]
    [InlineData(30, 4)]
    public void AddXp_LevelsUpAtThresholds(int xp, int expectedLevel)
    {
        var butterfly = CreateButterfly();

        butterfly.AddXp(xp);

        Assert.Equal(expectedLevel, butterfly.Level);
    }

        [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void AddXp_ZeroOrNegative_Throws(int amount)
    {
        var butterfly = CreateButterfly();

        Assert.Throws<ArgumentOutOfRangeException>(() => butterfly.AddXp(amount));
    }
}