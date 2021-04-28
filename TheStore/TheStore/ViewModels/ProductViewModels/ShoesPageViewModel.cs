using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TheStore.Models;
using TheStore.Services;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    internal class ShoesPageViewModel : BaseViewModel
    {
        public Command<Shoes> ItemTappedCommand { get; }
        public Command<Shoes> AddToCartCommand { get; }

        private ObservableCollection<Shoes> shoes;
        private readonly IGenericRepo<Shoes> genericRepoShoes;
        public ICommand PerformSearch => new Command<string>(OnSearch);

        public ObservableCollection<Shoes> Shoes
        {
            get { return shoes; }
            set
            {
                shoes = value;
                OnPropertyChanged(nameof(Shoes));
            }
        }

        public ShoesPageViewModel()
        {
            genericRepoShoes = new GenericRepo<Shoes>();
            ItemTappedCommand = new Command<Shoes>(OnShoesSelected);
            AddToCartCommand = new Command<Shoes>(AddSelectedShoesToCart);
            RefreshShoes();
        }

        private void AddSelectedShoesToCart(Shoes shoes)
        {
            Cart.AddProductAsync(shoes);
        }
        private void SubtractSelectedShoesFromCart(Shoes shoes)
        {
            Cart.SubtractProduct(shoes);
        }

        private async void OnShoesSelected(Shoes shoes)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(ShoesDetailPage)}?{nameof(ShoesDetailPageViewModel.ShoesId)}={shoes.Id}");
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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void OnSearch(string query)
        {

            List<Shoes> shoes = await genericRepoShoes.FindProductsByNameAsync(query);
            Shoes = new ObservableCollection<Shoes>(shoes);
        }
    }
}