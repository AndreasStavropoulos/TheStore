using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<CartItem>> GetAllCartItemsAsync()
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.CartItems.ToListAsync();
            }
        }
    }
}
