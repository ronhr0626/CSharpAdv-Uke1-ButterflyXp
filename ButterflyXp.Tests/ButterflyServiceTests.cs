using ButterflyXp.Core;
using ButterflyXp.Core.Repository;

namespace ButterflyXp.Tests;

public class ButterflyServiceTests
{
    [Fact]
    public void Create_ThenGetById_ReturnsSameButterfly()
    {
        var service = new ButterflyService(new FakeButterflyRepository());

        var created = service.Create("Flora");
        var found = service.GetById(created.Id);

        Assert.NotNull(found);
        Assert.Equal("Flora", found.Name);
    }
}