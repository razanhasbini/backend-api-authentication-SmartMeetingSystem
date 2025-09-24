using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartMeetingSystem.Application.IService

{
    public interface IRoomGadgetService
    {
        Task<List<RoomGadget>> GetAllAsync();
        Task<RoomGadget> CreateAsync(RoomGadget item);
        Task<RoomGadget> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, RoomGadget item);
        Task<bool> DeleteAsync(int id);
    }
}
