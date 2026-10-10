using ButterflyXp.Core.Models;
using ButterflyXp.Core.Repository;

namespace ButterflyXp.Core;

public class ButterflyService
{
    private readonly IButterflyRepository _repository;

    public ButterflyService(IButterflyRepository repository)
    {
        _repository = repository;
    }

    public Butterfly Create(string name)
    {
        var butterfly = new Butterfly(name);
        _repository.Add(butterfly);
        return butterfly;
    }

    public Butterfly? GetById(Guid id) => _repository.GetById(id);
}