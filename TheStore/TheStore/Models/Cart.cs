namespace TheStore.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; }

        public void AddCartItem(Product product, int Quantity)
        {
            CartItem cartItem = new CartItem(product, Quantity);
            CartItems.Add(cartItem);
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