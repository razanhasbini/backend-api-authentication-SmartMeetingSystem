using Microsoft.EntityFrameworkCore;
using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Infrastructure.Repository
{
    public class RoomGadgetRepository : IRoomGadgetRepository
    {
        private readonly ApplicationDbContext _db;
        public RoomGadgetRepository(ApplicationDbContext db) { _db = db; }
        public Task<List<RoomGadget>> GetAllAsync() => _db.RoomGadgets.AsNoTracking().ToListAsync();
        public Task<RoomGadget> GetByIdAsync(int id) => _db.RoomGadgets.FindAsync(id).AsTask();
        public async Task<RoomGadget> AddAsync(RoomGadget item) { _db.RoomGadgets.Add(item); await _db.SaveChangesAsync(); return item; }
        public async Task<bool> UpdateAsync(RoomGadget item) { _db.RoomGadgets.Update(item); return await _db.SaveChangesAsync() > 0; }
        public async Task<bool> DeleteAsync(int id) { var rg = await _db.RoomGadgets.FindAsync(id); if (rg == null) return false; _db.RoomGadgets.Remove(rg); return await _db.SaveChangesAsync() > 0; }
    }
}
