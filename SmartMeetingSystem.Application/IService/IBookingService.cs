using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartMeetingSystem.Application.IService



{
    public interface IBookingService
    {
        Task<List<Booking>> GetAllAsync();
        Task<Booking> GetByIdAsync(int id);
        Task<Booking> CreateAsync(Booking booking);
        Task<bool> UpdateAsync(int id, Booking booking);
        Task<bool> DeleteAsync(int id);
    }
}
