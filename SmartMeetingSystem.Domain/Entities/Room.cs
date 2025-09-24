namespace SmartMeetingSystem.Domain.Entities;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Availability { get; set; } = true;

    public List<Booking> Bookings { get; set; } = new();
    public List<RoomGadget> RoomGadgets { get; set; } = new();
}
