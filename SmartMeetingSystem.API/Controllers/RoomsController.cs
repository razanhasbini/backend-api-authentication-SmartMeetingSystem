using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.API.Mappers;
using SmartMeetingSystem.Application.IService;

namespace SmartMeetingSystem.API.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class RoomsController : ControllerBase
{
    private readonly IRoomService _service;

    public RoomsController(IRoomService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RoomReadDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<RoomReadDto>>> GetAll()
    {
        var rooms = await _service.GetAllAsync();
        return Ok(rooms.Select(r => r.ToReadDto()));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(RoomReadDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RoomReadDto>> GetById(int id)
    {
        var room = await _service.GetByIdAsync(id);
        if (room is null) return NotFound();
        return Ok(room.ToReadDto());
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(RoomReadDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<RoomReadDto>> Create([FromBody] RoomCreateDto dto)
    {
        var entity = dto.ToEntity();
        var created = await _service.CreateAsync(entity);

    // Return 201 Created with Location header pointing to GET api/Rooms/{id}
    return CreatedAtAction(nameof(GetById), new { id = created.Id }, created.ToReadDto());
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(int id, [FromBody] RoomUpdateDto dto)
    {
        var current = await _service.GetByIdAsync(id);
        if (current is null) return NotFound();
        dto.UpdateEntity(current);
        var ok = await _service.UpdateAsync(id, current);
        if (!ok) return BadRequest();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(int id)
    {
        var ok = await _service.DeleteAsync(id);
        if (!ok) return NotFound();
        return NoContent();
    }
}
