using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.Service
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _repo;

        public BookingService(IBookingRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Booking>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Booking> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public Task<Booking> CreateAsync(Booking booking) => _repo.AddAsync(booking);

        public Task<bool> UpdateAsync(int id, Booking booking)
        {
            if (id != booking.Id) return Task.FromResult(false);
            return _repo.UpdateAsync(booking);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
