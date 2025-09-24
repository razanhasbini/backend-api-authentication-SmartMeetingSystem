using Microsoft.EntityFrameworkCore;
using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Domain.Entities;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Infrastructure.Repository
{
    public class MomRepository : IMomRepository
    {
        private readonly ApplicationDbContext _db;
        public MomRepository(ApplicationDbContext db) { _db = db; }
        public Task<Mom?> GetByBookingIdAsync(int bookingId) => _db.Moms.AsNoTracking().FirstOrDefaultAsync(m => m.BookingId == bookingId);
        public async Task<Mom> UpsertAsync(Mom mom)
        {
            var existing = await _db.Moms.FirstOrDefaultAsync(m => m.BookingId == mom.BookingId);
            if (existing is null) { _db.Moms.Add(mom); }
            else
            {
                existing.MeetingTitle = mom.MeetingTitle;
                existing.DiscussionPoints = mom.DiscussionPoints;
                existing.Decisions = mom.Decisions;
                existing.FileSummary = mom.FileSummary;
                _db.Moms.Update(existing);
                mom = existing;
            }
            await _db.SaveChangesAsync();
            return mom;
        }
        public async Task<bool> DeleteByBookingIdAsync(int bookingId)
        {
            var existing = await _db.Moms.FirstOrDefaultAsync(m => m.BookingId == bookingId);
            if (existing is null) return false;
            _db.Moms.Remove(existing);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
