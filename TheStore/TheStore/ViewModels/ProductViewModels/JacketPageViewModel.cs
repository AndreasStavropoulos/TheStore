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
    public class JacketPageViewModel : BaseViewModel
    {
        public Command<Jacket> ItemTappedCommand { get; }
        public Command<Jacket> AddToCartCommand { get; }

        private readonly IGenericRepo<Jacket> genericRepoJackets;
        private ObservableCollection<Jacket> jacket;

        public ObservableCollection<Jacket> Jackets
        {
            get { return jacket; }
            set
            {
                jacket = value;
                OnPropertyChanged(nameof(Jackets));
            }
        }

        public JacketPageViewModel()
        {
            genericRepoJackets = new GenericRepo<Jacket>();
            ItemTappedCommand = new Command<Jacket>(OnJacketSelected);
            AddToCartCommand = new Command<Jacket>(AddSelectedJacketToCart);
            RefreshJackets();            
        }

        private void AddSelectedJacketToCart(Jacket jacket)
        {
            Cart.AddProduct(jacket);
        }
        private void SubtractSelectedJacketFromCart(Jacket jacket)
        {
            Cart.SubtractProduct(jacket);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            //Jackets = DataService.GetSearchResults(query);
        });

        //private List<string> searchResults = Jackets;
        //public List<string> SearchResults
        //{
        //    get
        //    {
        //        return searchResults;
        //    }
        //    set
        //    {
        //        searchResults = value;
        //        NotifyPropertyChanged();
        //    }
        //}

    }
}