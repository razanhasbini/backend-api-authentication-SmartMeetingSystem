namespace SmartMeetingSystem.API.DTOs;

public class MomUpsertDto
{
    public int BookingId { get; set; }
    public string MeetingTitle { get; set; } = string.Empty;
    public string DiscussionPoints { get; set; } = string.Empty;
    public string Decisions { get; set; } = string.Empty;
    public string FileSummary { get; set; } = string.Empty;
}

public class MomReadDto
{
    public int Id { get; set; }
    public int BookingId { get; set; }
    public string MeetingTitle { get; set; } = string.Empty;
    public string DiscussionPoints { get; set; } = string.Empty;
    public string Decisions { get; set; } = string.Empty;
    public string FileSummary { get; set; } = string.Empty;
}
