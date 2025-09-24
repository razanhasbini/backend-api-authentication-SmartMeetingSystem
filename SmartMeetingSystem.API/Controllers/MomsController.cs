using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/bookings/{bookingId:int}/mom")]
public class MomsController : ControllerBase
{
    private readonly IMomService _service;
    public MomsController(IMomService service) { _service = service; }

    [HttpGet]
    public async Task<IActionResult> Get(int bookingId)
    {
        var m = await _service.GetByBookingIdAsync(bookingId);
        return m is null ? NotFound() : Ok(m);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(int bookingId, MomUpsertDto dto)
    {
        var mom = new Mom { BookingId = bookingId, MeetingTitle = dto.MeetingTitle, DiscussionPoints = dto.DiscussionPoints, Decisions = dto.Decisions, FileSummary = dto.FileSummary };
        var saved = await _service.UpsertAsync(mom);
        return Ok(saved);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int bookingId)
    {
        var ok = await _service.DeleteByBookingIdAsync(bookingId);
        return ok ? NoContent() : NotFound();
    }
}
