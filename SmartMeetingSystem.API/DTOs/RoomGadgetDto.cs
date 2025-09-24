namespace SmartMeetingSystem.API.DTOs;

public class RoomGadgetCreateDto
{
    public int RoomId { get; set; }
    public int GadgetId { get; set; }
    public string? GadgetName { get; set; }
}

public class RoomGadgetUpdateDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GadgetId { get; set; }
    public string? GadgetName { get; set; }
}

public class RoomGadgetReadDto
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public int GadgetId { get; set; }
    public string? GadgetName { get; set; }
}
