using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.Application.IService;

public interface IRoomService
{
    Task<Room> CreateAsync(Room entity);
    Task<IEnumerable<Room>> GetAllAsync();
    Task<Room?> GetByIdAsync(int id);
    Task<bool> UpdateAsync(int id, Room entity);
    Task<bool> DeleteAsync(int id);
}
