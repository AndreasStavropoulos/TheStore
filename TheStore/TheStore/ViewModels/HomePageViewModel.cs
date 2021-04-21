using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TheStore.Models;
using TheStore.Services;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        public ICommand GoToJeansCommand { get; }
        public ICommand GoToTshirtsCommand { get; }
        public ICommand GoToJacketsCommand { get; }
        public ICommand GoToShoesCommand { get; }
        //public ICommand GoToUserCommand { get; }
        //public ICommand GoToCartCommand { get; }

        private ObservableCollection<Jeans> jeans;
        public ObservableCollection<Jeans> Jeans
        {
            get { return jeans; }
            set
            {
                jeans = value;
                OnPropertyChanged(nameof(Jeans));
            }
        }

        private ObservableCollection<TShirt> tShirts;
        public ObservableCollection<TShirt> TShirts
        {
            get { return tShirts; }
            set
            {
                tShirts = value;
                OnPropertyChanged(nameof(TShirts));
            }
        }

        private ObservableCollection<Jacket> jackets;
        public ObservableCollection<Jacket> Jackets
        {
            get { return jackets; }
            set
            {
                jackets = value;
                OnPropertyChanged(nameof(Jackets));
            }
        }

        private ObservableCollection<Shoes> shoes;
        public ObservableCollection<Shoes> Shoes
        {
            get { return shoes; }
            set
            {
                shoes = value;
                OnPropertyChanged(nameof(Shoes));
            }
        }

        private IGenericRepo<Jeans> genericRepoJeans;
        private IGenericRepo<TShirt> genericRepoTShirt;
        private IGenericRepo<Jacket> genericRepoJacket;
        private IGenericRepo<Shoes> genericRepoShoes;

        public HomePageViewModel()
        {
            GoToJeansCommand = new Command(GoToJeans);
            GoToTshirtsCommand = new Command(GoToTshirts);
            GoToJacketsCommand = new Command(GoToJackets);
            GoToShoesCommand = new Command(GoToShoes);
            //GoToUserCommand = new Command(GoToUser);
            // GoToCartCommand = new Command(GoToCart);

            genericRepoJeans = new GenericRepo<Jeans>();
            genericRepoTShirt = new GenericRepo<TShirt>();
            genericRepoJacket = new GenericRepo<Jacket>();
            genericRepoShoes = new GenericRepo<Shoes>();

            RefreshJeans();
            RefreshTShirts();
            RefreshJackets();
            RefreshShoes();
            
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

        private async void RefreshJeans()
        {
            try
            {
                List<Jeans> jeans = await genericRepoJeans.GetAllProductsAsync();
                Jeans = new ObservableCollection<Jeans>(jeans);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }

        private async void RefreshTShirts()
        {
            try
            {
                List<TShirt> tShirts = await genericRepoTShirt.GetAllProductsAsync();
                TShirts = new ObservableCollection<TShirt>(tShirts);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }

        private async void RefreshJackets()
        {
            try
            {
                List<Jacket> jackets = await genericRepoJacket.GetAllProductsAsync();
                Jackets = new ObservableCollection<Jacket>(jackets);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }

        private async void RefreshShoes()
        {
            try
            {
                List<Shoes> shoes = await genericRepoShoes.GetAllProductsAsync();
                Shoes = new ObservableCollection<Shoes>(shoes);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
    }
}