using System.Windows.Input;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    internal class HomePageViewModel : BaseViewModel
    {
        public ICommand GoToJeansCommand;
        public ICommand GoToTshirtsCommand;
        public ICommand GoToJacketsCommand;
        public ICommand GoToShoesCommand;
        // public ICommand GoToUserCommand;
        //public ICommand GoToCartCommand;

        public HomePageViewModel()
        {
            GoToJeansCommand = new Command(GoToJeans);
            GoToTshirtsCommand = new Command(GoToTshirts);
            GoToJacketsCommand = new Command(GoToJackets);
            GoToShoesCommand = new Command(GoToShoes);
            // GoToUserCommand = new Command(GoToUser);
            // GoToCartCommand = new Command(GoToCart);
        }

        private async void GoToJeans()
        {
            await Shell.Current.GoToAsync(nameof(JeansPage));
        }

        private async void GoToTshirts()
        {
            await Shell.Current.GoToAsync(nameof(TShirtPage));
        }

        private async void GoToJackets()
        {
            await Shell.Current.GoToAsync(nameof(JacketPage));
        }

        private async void GoToShoes()
        {
            await Shell.Current.GoToAsync(nameof(ShoesPage));
        }

        //private async void GoToUser()
        //{
        //    await Shell.Current.GoToAsync(nameof(LoginPage));
        //}
        //private async void GoToCart()
        //{
        //    await Shell.Current.GoToAsync(nameof(CartPage));
        //}
    }
}