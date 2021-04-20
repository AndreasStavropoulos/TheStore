using System.Collections.Generic;
using System.Threading.Tasks;
using TheStore.Models;

namespace TheStore.Services
{
    public interface IGenericRepo<T> where T : Product
    {
        Task DeleteProductAsync(T product);
        Task<T> FindProductByIdAsync(int id);
        Task<List<T>> FindProductsByNameAsync(string name);
        Task<List<T>> GetAllProductsAsync();
        Task SaveProductAsync(T product);
    }
}