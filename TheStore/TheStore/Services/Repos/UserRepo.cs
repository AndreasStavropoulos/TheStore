using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStore.Models;

namespace TheStore.Services
{
    public class UserRepo : IUserRepo
    {
        public async Task SaveUserAsync(User user)
        {
            using (var dbContext = new TheStoreContext())
            {
                if (user.Id == 0)
                {
                    await dbContext.AddAsync(user);
                }
                else
                {
                    dbContext.Update(user);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            using (var dbContext = new TheStoreContext())
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> FindUserByIdAsync(int id)
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.FindAsync<User>(id);
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.Users.ToListAsync();
            }
        }

        public async Task<User> FindUserByEMail(string email)
        {
            var ListOfUsers = await GetAllUsersAsync();
            return ListOfUsers.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserByIdAsync(int id)
        {
            using (var dbContext = new TheStoreContext())
            {
                return dbContext.Users.Include(x => x.CartItems)
                                      .ThenInclude(x => x.Product)
                                      .FirstOrDefault(y => y.Id == id);
            }
        }
    }
}