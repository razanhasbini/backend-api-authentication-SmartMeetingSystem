using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Mappers
{
    public static class RoomGadgetMappings
    {
        public static RoomGadget ToEntity(this RoomGadgetCreateDto dto) =>
            new RoomGadget
            {
                RoomId = dto.RoomId,
                GadgetId = dto.GadgetId
            };

        public static RoomGadgetReadDto ToReadDto(this RoomGadget entity) =>
            new RoomGadgetReadDto
            {
                Id = entity.Id,
                RoomId = entity.RoomId,
                GadgetId = entity.GadgetId
            };
    }
}
