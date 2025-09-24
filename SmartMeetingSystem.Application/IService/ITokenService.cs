using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.IServices;

public interface ITokenService
{
    Task<(string token, DateTime expires)> CreateAccessTokenAsync(AppUser user);
}
