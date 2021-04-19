using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheStore.Models;

namespace TheStore.Services
{
    internal class GenericRepo<T> where T : Product
    {
        public async Task AddItem(T product)
        {
            using (var dbContext = new TheStoreContext())
            {
                if (product.Id == 0)
                {
                    await dbContext.AddAsync(product);
                }
                else
                {
                    dbContext.Update(product);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<T> FindItemAsync(int id)
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.FindAsync<T>(id);
            }
        }
    }
}