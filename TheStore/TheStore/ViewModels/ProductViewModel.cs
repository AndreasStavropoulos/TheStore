using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
       
        public void AddJacket(Jacket jacket)
        {
            cart.AddJacket(jacket);
        }
    }
}