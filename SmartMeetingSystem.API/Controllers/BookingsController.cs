using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.API.Mappers;
using SmartMeetingSystem.Application.IService;

namespace SmartMeetingSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _service;

    public BookingsController(IBookingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookingReadDto>>> GetAll()
    {
        var items = await _service.GetAllAsync();
        return Ok(items.Select(x => x.ToReadDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BookingReadDto>> GetById(int id)
    {
        var item = await _service.GetByIdAsync(id);
        if (item is null) return NotFound();
        return Ok(item.ToReadDto());
    }

    [HttpPost]
    public async Task<ActionResult<BookingReadDto>> Create([FromBody] BookingCreateDto dto)
    {
        var entity = dto.ToEntity();
        var created = await _service.CreateAsync(entity);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToReadDto());
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update(int id, [FromBody] BookingUpdateDto dto)
    {
        var current = await _service.GetByIdAsync(id);
        if (current is null) return NotFound();
        dto.UpdateEntity(current);
        var ok = await _service.UpdateAsync(id, current);
        if (!ok) return BadRequest();
        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
