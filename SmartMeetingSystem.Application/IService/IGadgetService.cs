using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartMeetingSystem.Application.IService


{
    public interface IGadgetService
    {
        Task<List<Gadget>> GetAllAsync();
        Task<Gadget> CreateAsync(Gadget gadget);
        Task<Gadget> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, Gadget gadget);
        Task<bool> DeleteAsync(int id);
    }
}
