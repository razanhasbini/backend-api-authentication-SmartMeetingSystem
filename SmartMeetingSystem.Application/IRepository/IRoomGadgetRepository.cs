using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartMeetingSystem.Application.IRepository

{
    public interface IRoomGadgetRepository
    {
        Task<List<RoomGadget>> GetAllAsync();
        Task<RoomGadget> AddAsync(RoomGadget item);
        Task<RoomGadget> GetByIdAsync(int id);
        Task<bool> UpdateAsync(RoomGadget item);
        Task<bool> DeleteAsync(int id);
    }
}
