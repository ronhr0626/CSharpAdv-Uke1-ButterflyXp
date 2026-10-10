using ButterflyXp.Core.Models;

namespace ButterflyXp.Core.Repository;

public interface IButterflyRepository
{
    void Add(Butterfly butterfly);
    Butterfly? GetById(Guid id);
}