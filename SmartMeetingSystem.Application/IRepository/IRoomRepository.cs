using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.IRepository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllAsync();
        Task<Room> GetByIdAsync(int id);
        Task<Room> AddAsync(Room room);
        Task<bool> UpdateAsync(Room room);
        Task<bool> DeleteAsync(int id);
    }
}
