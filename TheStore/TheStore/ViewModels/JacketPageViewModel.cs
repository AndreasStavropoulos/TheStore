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
    internal class JacketPageViewModel : ProductViewModel
    {
        public Command<Jacket> ItemTapped { get; }
        public Command<Jacket> AddToCartCommand { get; }

        private ObservableCollection<Jacket> jacket;
        private IGenericRepo<Jacket> genericRepoJackets;

        public ObservableCollection<Jacket> Jackets
        {
            get { return jacket; }
            set
            {
                jacket = value;
                OnPropertyChanged(nameof(Jacket));
            }
        }

        public JacketPageViewModel()
        {
            genericRepoJackets = new GenericRepo<Jacket>();
            RefreshJackets();
            ItemTapped = new Command<Jacket>(OnJacketSelected);
            AddToCartCommand = new Command<Jacket>(AddSelectedJacketToCart);
        }

        private void AddSelectedJacketToCart(Jacket jacket)
        {
            cart.AddJacket(jacket);
        }

        private async void OnJacketSelected(Jacket jacket)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(JacketDetailPage)}?{nameof(JacketDetailPageViewModel.JacketId)}={jacket.Id}");
        }

        private async void RefreshJackets()
        {
            try
            {
                List<Jacket> jackets = await genericRepoJackets.GetAllProductsAsync();
                Jackets = new ObservableCollection<Jacket>(jackets);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
    }
}