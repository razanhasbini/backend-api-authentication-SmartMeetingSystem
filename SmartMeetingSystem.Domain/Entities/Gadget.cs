namespace SmartMeetingSystem.Domain.Entities;

public class Gadget
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<RoomGadget> RoomGadgets { get; set; } = new();
}
