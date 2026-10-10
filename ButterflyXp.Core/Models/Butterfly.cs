namespace ButterflyXp.Core.Models;

/// <summary>
/// A butterfly that gains XP and levels up through its life stages.
/// </summary>
public class Butterfly
{
    // Every new butterfly starts as an egg on level 1.
    private const int StartLevel = 1;

    public string Name { get; }
    public int Xp { get; private set; }
    public int Level => StartLevel;

    public Butterfly(string name)
    {
        Name = name;
    }

    public void AddXp(int amount)
    {
        Xp += amount;
    }
}