using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.Service
{
    public class RoomGadgetService : IRoomGadgetService
    {
        private readonly IRoomGadgetRepository _repo;
        public RoomGadgetService(IRoomGadgetRepository repo) { _repo = repo; }

        public Task<List<RoomGadget>> GetAllAsync() => _repo.GetAllAsync();
        public Task<RoomGadget> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<RoomGadget> CreateAsync(RoomGadget item) => _repo.AddAsync(item);
        public async Task<bool> UpdateAsync(int id, RoomGadget item) { if (id != item.Id) return false; return await _repo.UpdateAsync(item); }
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
