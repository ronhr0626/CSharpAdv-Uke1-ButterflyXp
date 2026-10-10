namespace ButterflyXp.Core.Models;

public class Butterfly
{
    public string Name { get; }
    public int Xp { get; }
    public int Level => 1;

    public Butterfly(string name)
    {
        Name = name;
    }
}