using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TheStore.Models;
using TheStore.Services;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    public class TShirtPageViewModel : BaseViewModel
    {
        public Command<TShirt> ItemTappedCommand { get; }
        public Command<TShirt> AddToCartCommand { get; }

        private ObservableCollection<TShirt> tShirts;
        private readonly IGenericRepo<TShirt> genericRepoTShirt;

        public ObservableCollection<TShirt> TShirts
        {
            get { return tShirts; }
            set
            {
                tShirts = value;
                OnPropertyChanged(nameof(TShirts));
            }
        }

        public TShirtPageViewModel()
        {
            genericRepoTShirt = new GenericRepo<TShirt>();
            RefreshTShirts();
        }

        private void AddSelectedTShirtToCart(TShirt tshirt)
        {
            Cart.AddProduct(tshirt);
        }
        private void SubtractSelectedTShirtFromCart(TShirt tshirt)
        {
            Cart.SubtractProduct(tshirt);
        }

        private async void OnTShirtSelected(TShirt tshirt)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(TShirtDetailPage)}?{nameof(TShirtDetailPageViewModel.TShirtId)}={tshirt.Id}");
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
    }
}