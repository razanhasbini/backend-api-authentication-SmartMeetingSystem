using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Mappers
{
    public static class BookingMappings
    {
        public static Booking ToEntity(this BookingCreateDto dto) =>
            new Booking
            {
                Title = dto.Title,
                Description = dto.Description,
                RoomId = dto.RoomId,
                UserId = dto.UserId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime
            };

        public static void UpdateEntity(this BookingUpdateDto dto, Booking entity)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.RoomId = dto.RoomId;
            entity.UserId = dto.UserId;
            entity.StartTime = dto.StartTime;
            entity.EndTime = dto.EndTime;
        }

        public static BookingReadDto ToReadDto(this Booking entity) =>
            new BookingReadDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                RoomId = entity.RoomId,
                UserId = entity.UserId,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime
            };
    }
}
