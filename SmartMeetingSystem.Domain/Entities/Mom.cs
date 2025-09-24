namespace SmartMeetingSystem.Domain.Entities
{
    public class Mom
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; } = null!;
        public string MeetingTitle { get; set; } = string.Empty;
        public string DiscussionPoints { get; set; } = string.Empty;
        public string Decisions { get; set; } = string.Empty;
        public string FileSummary { get; set; } = string.Empty;
    }
}
