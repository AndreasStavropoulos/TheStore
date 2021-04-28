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
    [QueryProperty(nameof(ShoesId), nameof(ShoesId))]
    class ShoesDetailPageViewModel : BaseViewModel
    {
        private readonly IGenericRepo<Shoes> shoesRepo;
        public ICommand AddToCartCommand { get; }
        private Shoes selectedShoes;

        public Shoes SelectedShoes
        {
            get { return selectedShoes; }
            set
            {
                selectedShoes = value;
                OnPropertyChanged(nameof(SelectedShoes));
            }
        }

        private int shoesId;

        public int ShoesId
        {
            get { return shoesId; }
            set
            {
                shoesId = value;
                LoadShoes(value);
            }
        }

        public ShoesDetailPageViewModel()
        {
            SelectedShoes = new Shoes();
            shoesRepo = new GenericRepo<Shoes>();
            AddToCartCommand = new Command(AddShoesToCart);
        }

        public async void AddShoesToCart()
        {
            Cart.AddProductAsync(SelectedShoes);
            await Shell.Current.GoToAsync("..");
        }

        public void SubtractShoesFromCart()
        {
            Cart.SubtractProduct(SelectedShoes);
        }

        private void LoadShoes(int id)
        {
            try
            {
                var shoes = shoesRepo.FindProductByIdAsync(id);
                SelectedShoes = shoes.Result;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load place");
            }
        }
    }
}
