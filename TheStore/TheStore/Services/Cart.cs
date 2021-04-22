using System.Collections.Generic;
using TheStore.Services;

namespace TheStore.Models
{
    public class Cart
    {
        private static Cart Instance { get; set; }
        public CartItemRepo cartItemRepo;
        public List<CartItem> CartItems { get; set; }

        private Cart()
        {
            cartItemRepo = new CartItemRepo();
            CartItems = new List<CartItem>();
        }

        public static Cart GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Cart();
            }
            return Instance;
        }

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

        public void AddJacket(Jacket jacket)
        {
            var cartItem = CartItems.Find(x => x.Product.Id == jacket.Id);

            if (cartItem == null)
            {
                CartItem newCartitem = new CartItem();
                newCartitem.Quantity = 1;
                newCartitem.Product = jacket;
                CartItems.Add(newCartitem);
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public List<CartItem> GetCartList()
        {
            return CartItems;
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