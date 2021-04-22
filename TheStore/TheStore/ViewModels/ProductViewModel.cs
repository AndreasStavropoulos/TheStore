using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public Cart cart;

        public ProductViewModel()
        {
            cart = Cart.GetInstance();
        }

        public void AddJacket(Jacket jacket)
        {
            cart.AddJacket(jacket);
        }
    }
}