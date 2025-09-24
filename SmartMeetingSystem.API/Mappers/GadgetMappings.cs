using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Mappers
{
    public static class GadgetMappings
    {
        public static Gadget ToEntity(this GadgetCreateDto dto) =>
            new Gadget
            {
                Name = dto.Name,
                Description = dto.Description
            };

        public static void UpdateEntity(this GadgetUpdateDto dto, Gadget entity)
        {
            entity.Name = dto.Name;
            entity.Description = dto.Description;
        }

        public static GadgetReadDto ToReadDto(this Gadget entity) =>
            new GadgetReadDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
    }
}
