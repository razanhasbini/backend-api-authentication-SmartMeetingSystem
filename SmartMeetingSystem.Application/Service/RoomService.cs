using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;

namespace SmartMeetingSystem.Application.Service;

public class RoomService : IRoomService
{
    private readonly IRoomRepository _repo;

    public RoomService(IRoomRepository repo)
    {
        _repo = repo;
    }

    public async Task<Room> CreateAsync(Room entity)
    {
        return await _repo.AddAsync(entity);
    }

    public async Task<IEnumerable<Room>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Room?> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<bool> UpdateAsync(int id, Room entity)
    {
        entity.Id = id;
        return await _repo.UpdateAsync(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repo.DeleteAsync(id);
    }
}
