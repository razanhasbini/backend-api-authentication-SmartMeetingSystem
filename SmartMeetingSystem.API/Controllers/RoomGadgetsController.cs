using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RoomGadgetsController : ControllerBase
{
    private readonly IRoomGadgetService _svc;
    public RoomGadgetsController(IRoomGadgetService svc) { _svc = svc; }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var rg = await _svc.GetByIdAsync(id);
        return rg is null ? NotFound() : Ok(rg);
    }

    [HttpPost]
    public async Task<IActionResult> Create(RoomGadgetCreateDto dto)
    {
        var rg = await _svc.CreateAsync(new RoomGadget { RoomId = dto.RoomId, GadgetId = dto.GadgetId, GadgetName = dto.GadgetName });
        return CreatedAtAction(nameof(Get), new { id = rg.Id }, rg);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, RoomGadgetUpdateDto dto)
    {
        var rg = await _svc.GetByIdAsync(id);
        if (rg is null) return NotFound();
        rg.RoomId = dto.RoomId;
        rg.GadgetId = dto.GadgetId;
        rg.GadgetName = dto.GadgetName;
        var ok = await _svc.UpdateAsync(id, rg);
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
