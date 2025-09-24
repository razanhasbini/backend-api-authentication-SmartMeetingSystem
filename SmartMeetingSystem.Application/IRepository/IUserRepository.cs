using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMeetingSystem.Application.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
    }
}
