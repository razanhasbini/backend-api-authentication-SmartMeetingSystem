using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.Service
{
    public class MomService : IMomService
    {
        private readonly IMomRepository _repo;

        public MomService(IMomRepository repo)
        {
            _repo = repo;
        }

        public Task<Mom?> GetByBookingIdAsync(int bookingId) => _repo.GetByBookingIdAsync(bookingId);

        public Task<Mom> UpsertAsync(Mom mom) => _repo.UpsertAsync(mom);

        public Task<bool> DeleteByBookingIdAsync(int bookingId) => _repo.DeleteByBookingIdAsync(bookingId);
    }
}
