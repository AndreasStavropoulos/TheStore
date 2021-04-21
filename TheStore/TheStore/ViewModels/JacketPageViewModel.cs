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
    internal class JacketPageViewModel : BaseViewModel
    {

        public Command<Jacket> ItemTapped { get; }

        private async void OnJacketSelected(Jacket jacket)
        {
            await Shell.Current.GoToAsync(
                $"{nameof(JacketDetailPage)}?{nameof(JacketDetailPageViewModel.JacketId)}={jacket.Id}");
        }

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