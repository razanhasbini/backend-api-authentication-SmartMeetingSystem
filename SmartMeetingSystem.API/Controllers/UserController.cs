using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _svc;
    public UsersController(IUserService svc) { _svc = svc; }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _svc.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var u = await _svc.GetByIdAsync(id);
        return u is null ? NotFound() : Ok(u);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserCreateDto dto)
    {
        var u = await _svc.CreateAsync(new User { Name = dto.Name, Email = dto.Email, Phone = dto.Phone, Role = dto.Role });
        return CreatedAtAction(nameof(Get), new { id = u.Id }, u);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UserUpdateDto dto)
    {
        var u = await _svc.GetByIdAsync(id);
        if (u is null) return NotFound();
        u.Name = dto.Name;
        u.Email = dto.Email;
        u.Phone = dto.Phone;
        u.Role = dto.Role;
        var ok = await _svc.UpdateAsync(id, u);
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
