namespace ButterflyXp.Core.Models;

/// <summary>
/// A butterfly that gains XP and levels up through its life stages.
/// </summary>
public class Butterfly
{
    // Every new butterfly starts as an egg on level 1.
    private const int StartLevel = 1;

    // XP needed to reach each stage.
    private const int LarvaXp = 10;
    private const int PupaXp = 20;
    private const int AdultXp = 30;

    public string Name { get; }
    public int Xp { get; private set; }

    public int Level => Xp switch
    {
        >= AdultXp => 4,
        >= PupaXp  => 3,
        >= LarvaXp => 2,
        _          => StartLevel
    };

    public Butterfly(string name)
    {
        Name = name;
    }

    public void AddXp(int amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "XP must be greater than 0.");
        }

        Xp += amount;
    }
}