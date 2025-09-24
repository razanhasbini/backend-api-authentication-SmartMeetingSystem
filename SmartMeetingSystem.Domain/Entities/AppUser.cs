using Microsoft.AspNetCore.Identity;

namespace SmartMeetingSystem.Domain.Entities;

public class AppUser : IdentityUser
{
    public string? FullName { get; set; }
}
