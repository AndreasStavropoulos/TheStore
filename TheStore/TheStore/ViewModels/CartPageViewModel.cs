using TheStore.Models;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        public Command<CartItem> SubstractProductCommand { get; set; }
        public Command<CartItem> AddProductCommand { get; set; }

        public CartPageViewModel()
        {
            SubstractProductCommand = new Command<CartItem>(SubstractProduct);
            AddProductCommand = new Command<CartItem>(AddProduct);
        }

        private void AddProduct(CartItem cartItem)
        {
            Cart.AddProduct(cartItem);
        }

        private void SubstractProduct(CartItem cartItem)
        {
            Cart.SubtractProduct(cartItem);
        }
    }
}