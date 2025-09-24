using SmartMeetingSystem.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SmartMeetingSystem.Application.IService

{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, User user);
        Task<bool> DeleteAsync(int id);
    }
}
