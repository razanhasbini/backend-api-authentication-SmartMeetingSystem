using SmartMeetingSystem.Domain.Entities;
using System.Threading.Tasks;
namespace SmartMeetingSystem.Application.IService


{
    public interface IMomService
    {
        Task<Mom> GetByBookingIdAsync(int bookingId);
        Task<Mom> UpsertAsync(Mom mom);
        Task<bool> DeleteByBookingIdAsync(int bookingId);
    }
}
