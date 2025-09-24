using SmartMeetingSystem.API.DTOs;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.API.Mappers
{
    public static class UserMappings
    {
        public static User ToEntity(this UserCreateDto dto) =>
            new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = dto.Role
            };

        public static void UpdateEntity(this UserUpdateDto dto, User entity)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            entity.Role = dto.Role;
        }

        public static UserReadDto ToReadDto(this User entity) =>
            new UserReadDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Phone = entity.Phone,
                Role = entity.Role
            };
    }
}
