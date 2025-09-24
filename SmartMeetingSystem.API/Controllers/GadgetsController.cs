using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GadgetsController : ControllerBase
{
    private readonly IGadgetService _svc;
    public GadgetsController(IGadgetService svc) { _svc = svc; }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var g = await _svc.GetByIdAsync(id);
        return g is null ? NotFound() : Ok(g);
    }

    [HttpPost]
    public async Task<IActionResult> Create(GadgetCreateDto dto)
    {
        var g = await _svc.CreateAsync(new Gadget { Name = dto.Name, Description = dto.Description });
        return CreatedAtAction(nameof(Get), new { id = g.Id }, g);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, GadgetUpdateDto dto)
    {
        var g = await _svc.GetByIdAsync(id);
        if (g is null) return NotFound();
        g.Name = dto.Name;
        g.Description = dto.Description;
        var ok = await _svc.UpdateAsync(id, g);
        return ok ? NoContent() : BadRequest();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _svc.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
}
