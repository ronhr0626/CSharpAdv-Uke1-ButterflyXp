using ButterflyXp.Core.Models;

namespace ButterflyXp.Core.Repository;

public class FakeButterflyRepository : IButterflyRepository
{
    private readonly List<Butterfly> _butterflies = new();

    public void Add(Butterfly butterfly) => _butterflies.Add(butterfly);

    public Butterfly? GetById(Guid id) =>
        _butterflies.FirstOrDefault(b => b.Id == id);
}