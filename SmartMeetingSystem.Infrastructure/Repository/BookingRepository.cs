using Microsoft.EntityFrameworkCore;
using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Infrastructure.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _db;
        public BookingRepository(ApplicationDbContext db) { _db = db; }
        public Task<List<Booking>> GetAllAsync() => _db.Bookings.AsNoTracking().ToListAsync();
        public Task<Booking> GetByIdAsync(int id) => _db.Bookings.FindAsync(id).AsTask();
        public async Task<Booking> AddAsync(Booking booking) { _db.Bookings.Add(booking); await _db.SaveChangesAsync(); return booking; }
        public async Task<bool> UpdateAsync(Booking booking) { _db.Bookings.Update(booking); return await _db.SaveChangesAsync() > 0; }
        public async Task<bool> DeleteAsync(int id) { var b = await _db.Bookings.FindAsync(id); if (b == null) return false; _db.Bookings.Remove(b); return await _db.SaveChangesAsync() > 0; }
    }
}
