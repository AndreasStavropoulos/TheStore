using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheStore.Models;

namespace TheStore.Services
{
    public class GenericRepo<T> : IGenericRepo<T> where T : Product
    {
        public async Task SaveProductAsync(T product)
        {
            using (var dbContext = new TheStoreContext())
            {
                if (product.Id == 0)
                {
                    product.DateCreated = DateTime.Now;
                    await dbContext.AddAsync(product);
                }
                else
                {
                    product.DateModified = DateTime.Now;
                    dbContext.Update(product);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(T product)
        {
            using (var dbContext = new TheStoreContext())
            {
                dbContext.Remove(product);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<T>> GetAllProductsAsync()
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.Set<T>().ToListAsync();
            }
        }

        public async Task<T> FindProductByIdAsync(int id)
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.FindAsync<T>(id);
            }
        }

        public async Task<List<T>> FindProductsByNameAsync(string name)
        {
            var ListProducts = await GetAllProductsAsync();
            return (List<T>)ListProducts.Where(x => x.Name == name);
        }
    }
}