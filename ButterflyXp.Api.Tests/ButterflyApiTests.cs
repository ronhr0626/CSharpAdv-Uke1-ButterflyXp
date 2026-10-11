using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ButterflyXp.Api.Tests;

public class ButterflyApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private record ButterflyDto(Guid Id, string Name, int Xp, int Level);

    private readonly HttpClient _client;

    public ButterflyApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    private async Task<ButterflyDto> CreateButterflyAsync()
    {
        var response = await _client.PostAsJsonAsync("/butterflies", new { name = "Flora" });
        return (await response.Content.ReadFromJsonAsync<ButterflyDto>())!;
    }

    [Fact]
    public async Task Post_CreatesButterfly_Returns201()
    {
        var response = await _client.PostAsJsonAsync("/butterflies", new { name = "Flora" });

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }

    [Fact]
    public async Task Get_ExistingButterfly_Returns200()
    {
        var created = await CreateButterflyAsync();

        var response = await _client.GetAsync($"/butterflies/{created.Id}");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Get_UnknownButterfly_Returns404()
    {
        var response = await _client.GetAsync($"/butterflies/{Guid.NewGuid()}");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task AddXp_ValidAmount_Returns200()
    {
        var created = await CreateButterflyAsync();

        var response = await _client.PatchAsJsonAsync($"/butterflies/{created.Id}/xp", new { amount = 15 });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task AddXp_InvalidAmount_Returns400()
    {
        var created = await CreateButterflyAsync();

        var response = await _client.PatchAsJsonAsync($"/butterflies/{created.Id}/xp", new { amount = 0 });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task AddXp_UnknownButterfly_Returns404()
    {
        var response = await _client.PatchAsJsonAsync($"/butterflies/{Guid.NewGuid()}/xp", new { amount = 5 });

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}