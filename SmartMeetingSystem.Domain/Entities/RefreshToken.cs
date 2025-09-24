namespace SmartMeetingSystem.Domain.Entities;

public class RefreshToken
{
    public int Id { get; set; }
    public string Token { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public DateTime ExpiresAt { get; set; }
    public bool Revoked { get; set; }
}
