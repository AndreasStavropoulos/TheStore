using System.Collections.Generic;

namespace TheStore.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        
        public void RemoveOneCartItem(CartItem cartItem)
        {
            if (cartItem.Quantity == 1)
            {
                CartItems.Remove(cartItem);
            }
            else if (cartItem.Quantity > 1)
            {
                cartItem.Quantity -= 1;
            }
        }

        public void AddOneCartItem(CartItem cartItem)
        {
            cartItem.Quantity++;
        }

        public void RemoveCartItem(CartItem cartItem)
        {
            if (cartItem.Quantity >= 1)
            {
                CartItems.Remove(cartItem);
            }
        }
    }
}