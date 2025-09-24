using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartMeetingSystem.Application.IRepository
{
    public interface IGadgetRepository
    {
        Task<List<Gadget>> GetAllAsync();
        Task<Gadget> AddAsync(Gadget gadget);
        Task<Gadget> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Gadget gadget);
        Task<bool> DeleteAsync(int id);
    }
}
