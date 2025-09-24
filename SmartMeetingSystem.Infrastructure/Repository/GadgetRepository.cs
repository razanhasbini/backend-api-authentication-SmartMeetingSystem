using Microsoft.EntityFrameworkCore;
using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Infrastructure.Repository
{
    public class GadgetRepository : IGadgetRepository
    {
        private readonly ApplicationDbContext _db;
        public GadgetRepository(ApplicationDbContext db) { _db = db; }
        public Task<List<Gadget>> GetAllAsync() => _db.Gadgets.AsNoTracking().ToListAsync();
        public Task<Gadget> GetByIdAsync(int id) => _db.Gadgets.FindAsync(id).AsTask();
        public async Task<Gadget> AddAsync(Gadget gadget) { _db.Gadgets.Add(gadget); await _db.SaveChangesAsync(); return gadget; }
        public async Task<bool> UpdateAsync(Gadget gadget) { _db.Gadgets.Update(gadget); return await _db.SaveChangesAsync() > 0; }
        public async Task<bool> DeleteAsync(int id) { var g = await _db.Gadgets.FindAsync(id); if (g == null) return false; _db.Gadgets.Remove(g); return await _db.SaveChangesAsync() > 0; }
    }
}
