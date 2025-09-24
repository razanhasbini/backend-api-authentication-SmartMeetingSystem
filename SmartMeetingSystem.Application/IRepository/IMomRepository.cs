using SmartMeetingSystem.Domain.Entities;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.IRepository
{
    public interface IMomRepository
    {
        Task<Mom?> GetByBookingIdAsync(int bookingId);
        Task<Mom> UpsertAsync(Mom mom);
        Task<bool> DeleteByBookingIdAsync(int bookingId);
    }
}
