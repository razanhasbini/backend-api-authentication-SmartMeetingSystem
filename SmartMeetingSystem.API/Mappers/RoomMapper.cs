using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Mappers;

public static class RoomMapper
{
    public static Room ToEntity(this RoomCreateDto dto)
    {
        return new Room
        {
            Name = dto.Name,
            Location = dto.Location,
            Capacity = dto.Capacity,
            Description = dto.Description,
            Availability = dto.Availability
        };
    }

    public static void UpdateEntity(this RoomUpdateDto dto, Room entity)
    {
        entity.Name = dto.Name;
        entity.Location = dto.Location;
        entity.Capacity = dto.Capacity;
        entity.Description = dto.Description;
        entity.Availability = dto.Availability;
    }

    public static RoomReadDto ToReadDto(this Room entity)
    {
        return new RoomReadDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Location = entity.Location,
            Capacity = entity.Capacity,
            Description = entity.Description,
            Availability = entity.Availability
        };
    }
}
