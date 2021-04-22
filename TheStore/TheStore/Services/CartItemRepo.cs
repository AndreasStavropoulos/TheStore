using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheStore.Models;

namespace TheStore.Services
{
    public class CartItemRepo
    {
        public async Task SaveCartItemAsync(CartItem cartItem)
        {
            using (var dbContext = new TheStoreContext())
            {
                if (cartItem.Id == 0)
                {
                    await dbContext.CartItems.AddAsync(cartItem);
                }
                else
                {
                    dbContext.Update(cartItem);
                }

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<CartItem>> GetAllCartItemsAsync(bool includeProductData = false)
        {
            if (includeProductData)
            {
                using (var dbContext = new TheStoreContext())
                {
                    return await dbContext.CartItems.Include(x => x.Product).ToListAsync();
                }
            }
            else
            {
                using (var dbContext = new TheStoreContext())
                {
                    return await dbContext.CartItems.ToListAsync();
                }
            }
        }

        public async Task<List<CartItem>> GetCartItemsOfActiveUserAsync(User user)
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.CartItems.Include(y => y.Product).Where(x => x.User == user).ToListAsync();
            }
        }

        public void AddOneCartItem(CartItem cartItem)
        {
            if (true)
            {
            }

            cartItem.Quantity++;
        }
    }
}