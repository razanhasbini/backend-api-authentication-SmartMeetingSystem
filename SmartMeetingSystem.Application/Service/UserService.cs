using SmartMeetingSystem.Application.IRepository;
using SmartMeetingSystem.Application.IService;
using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo) { _repo = repo; }

        public Task<List<User>> GetAllAsync() => _repo.GetAllAsync();
        public Task<User> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
        public Task<User> CreateAsync(User user) => _repo.AddAsync(user);
        public async Task<bool> UpdateAsync(int id, User user) { if (id != user.Id) return false; return await _repo.UpdateAsync(user); }
        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}
