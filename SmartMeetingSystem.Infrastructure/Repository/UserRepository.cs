using Microsoft.EntityFrameworkCore;
using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) { _db = db; }
        public Task<List<User>> GetAllAsync() => _db.Users.AsNoTracking().ToListAsync();
        public Task<User> GetByIdAsync(int id) => _db.Users.FindAsync(id).AsTask();
        public async Task<User> AddAsync(User user) { _db.Users.Add(user); await _db.SaveChangesAsync(); return user; }
        public async Task<bool> UpdateAsync(User user) { _db.Users.Update(user); return await _db.SaveChangesAsync() > 0; }
        public async Task<bool> DeleteAsync(int id) { var u = await _db.Users.FindAsync(id); if (u == null) return false; _db.Users.Remove(u); return await _db.SaveChangesAsync() > 0; }
    }
}
