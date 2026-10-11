using ButterflyXp.Core;
using Microsoft.AspNetCore.Mvc;

namespace ButterflyXp.Api.Controllers;

[ApiController]
[Route("butterflies")]
public class ButterfliesController : ControllerBase
{
    private readonly ButterflyService _service;

    public ButterfliesController(ButterflyService service)
    {
        _service = service;
    }

    public record CreateButterflyRequest(string Name);
    public record AddXpRequest(int Amount);

    // POST /butterflies → 201
    [HttpPost]
    public IActionResult Create(CreateButterflyRequest request)
    {
        var butterfly = _service.Create(request.Name);
        return CreatedAtAction(nameof(GetById), new { id = butterfly.Id }, butterfly);
    }

    // GET /butterflies/{id} → 200 / 404
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var butterfly = _service.GetById(id);
        if (butterfly is null) return NotFound();

        return Ok(butterfly);
    }

    // PATCH /butterflies/{id}/xp → 200 / 400 / 404
    [HttpPatch("{id:guid}/xp")]
    public IActionResult AddXp(Guid id, AddXpRequest request)
    {
        if (request.Amount <= 0) return BadRequest("XP must be greater than 0.");

        var butterfly = _service.GetById(id);
        if (butterfly is null) return NotFound();

        butterfly.AddXp(request.Amount);
        return Ok(butterfly);
    }
}