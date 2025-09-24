namespace SmartMeetingSystem.Domain.Entities;

public class RoomGadget
{
    public int Id { get; set; }          
    public int RoomId { get; set; }
    public int GadgetId { get; set; }
    public string GadgetName { get; set; } = string.Empty; 

    public Room? Room { get; set; }
    public Gadget? Gadget { get; set; }
}
