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

        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return products; }
            set 
            { 
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private readonly IGenericRepo<Product> genericRepoProduct;

        public HomePageViewModel()
        {
            GoToJeansCommand = new Command(GoToJeans);
            GoToTshirtsCommand = new Command(GoToTshirts);
            GoToJacketsCommand = new Command(GoToJackets);
            GoToShoesCommand = new Command(GoToShoes);

            genericRepoProduct = new GenericRepo<Product>();

            RefreshProducts();


            UserRepo userRepo = new UserRepo();

            var user = new User
            {
                Id = 1,
                Name = "bhdsbfé"
            };
            userRepo.GetUserByIdAsync(user.Id);

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


        private async void RefreshProducts()
        {
            try
            {
                List<Product> products = await genericRepoProduct.GetAllProductsAsync();
                Products = new ObservableCollection<Product>(products);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
    }
}