using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.Service
{
    public class GadgetService : IGadgetService
    {
        private readonly IGadgetRepository _repo;
        public GadgetService(IGadgetRepository repo) { _repo = repo; }

        public Task<List<Gadget>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Gadget> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<Gadget> CreateAsync(Gadget gadget) => _repo.AddAsync(gadget);
        public async Task<bool> UpdateAsync(int id, Gadget gadget) { if (id != gadget.Id) return false; return await _repo.UpdateAsync(gadget); }
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
