using System.Collections.Generic;
using System.Threading.Tasks;
using TheStore.Models;

namespace TheStore.Services
{
    public interface IUserRepo
    {
        Task DeleteUserAsync(User user);
        Task<User> FindUserByIdAsync(int id);
        Task SaveUserAsync(User user);
        Task<User> FindUserByEMail(string email);
    }
}