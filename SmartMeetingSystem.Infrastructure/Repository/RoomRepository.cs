using Microsoft.EntityFrameworkCore;
using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Domain.Entities;
using SmartMeetingSystem.Infrastructure;

namespace SmartMeetingSystem.Infrastructure.Repository;

public class RoomRepository : IRoomRepository
{
    private readonly ApplicationDbContext _context;

    public RoomRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Room> AddAsync(Room room)
    {
        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();
        return room;
    }

    public async Task<List<Room>> GetAllAsync()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> UpdateAsync(Room room)
    {
        _context.Rooms.Update(room);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return false;

        _context.Rooms.Remove(room);
        return await _context.SaveChangesAsync() > 0;
    }
}
