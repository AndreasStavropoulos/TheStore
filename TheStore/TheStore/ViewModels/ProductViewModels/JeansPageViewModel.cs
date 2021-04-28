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
    class JeansPageViewModel :BaseViewModel
    {
        public Command<Jeans> ItemTappedCommand { get; }
        public Command<Jeans> AddToCartCommand { get; }

        private ObservableCollection<Jeans> jeans;
        private readonly IGenericRepo<Jeans> genericRepoJeans;
        public ICommand PerformSearch => new Command<string>(OnSearch);

        public ObservableCollection<Jeans> Jeans
        {
            get { return jeans; }
            set
            {
                jeans = value;
                OnPropertyChanged(nameof(Jeans));
            }
        }

        public JeansPageViewModel()
        {
            genericRepoJeans = new GenericRepo<Jeans>();
            ItemTappedCommand = new Command<Jeans>(OnJeansSelected);
            AddToCartCommand = new Command<Jeans>(AddSelectedJeansToCart);
            RefreshJeans();
        }

        private void AddSelectedJeansToCart(Jeans jeans)
        {
            Cart.AddProductAsync(jeans);
        }
        private void SubtractSelectedJeansFromCart(Jeans jeans)
        {
            Cart.SubtractProduct(jeans);
        }

        private async void OnJeansSelected(Jeans jeans)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(JeansDetailPage)}?{nameof(JeansDetailPageViewModel.JeansId)}={jeans.Id}");
        }

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
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       

        private async void OnSearch(string query)
        {

            List<Jeans> jeans = await genericRepoJeans.FindProductsByNameAsync(query);
            Jeans = new ObservableCollection<Jeans>(jeans);
        }
    }
}
