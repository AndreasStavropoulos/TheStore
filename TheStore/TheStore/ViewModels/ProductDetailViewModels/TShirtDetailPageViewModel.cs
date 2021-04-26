using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using TheStore.Models;
using TheStore.Services;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    [QueryProperty(nameof(TShirtId), nameof(TShirtId))]
    class TShirtDetailPageViewModel : BaseViewModel
    {
        private readonly IGenericRepo<TShirt> tshirtRepo;
        public ICommand AddToCartCommand { get; }
        private TShirt selectedTShirt;

        public TShirt SelectedTShirt
        {
            get { return selectedTShirt; }
            set 
            { 
                selectedTShirt = value;
                OnPropertyChanged(nameof(SelectedTShirt));
            }
        }

        private int tshirtId;

        public int TShirtId
        {
            get { return tshirtId; }
            set 
            { 
                tshirtId = value;
                LoadTShirt(value);
            }
        }

        public TShirtDetailPageViewModel()
        {
            SelectedTShirt = new TShirt();
            tshirtRepo = new GenericRepo<TShirt>();
            AddToCartCommand = new Command(AddTShirtToCart);
        }

        public async void AddTShirtToCart()
        {
            Cart.AddProduct(SelectedTShirt);
            await App.Current.MainPage.DisplayAlert("Shopping Cart", "You added a product to your shopping cart. Continue Shopping", "Ok");
            await Shell.Current.GoToAsync("..");
        }

        public void SubtractTShirtFromCart()
        {
            Cart.SubtractProduct(SelectedTShirt);
        }

        private void LoadTShirt(int id)
        {
            try
            {
                var tshirt = tshirtRepo.FindProductByIdAsync(id);
                SelectedTShirt = tshirt.Result;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load place");
            }
        }

    }
}
