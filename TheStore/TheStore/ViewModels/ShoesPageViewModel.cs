using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    internal class ShoesPageViewModel : BaseViewModel
    {
        private ObservableCollection<Shoes> shoes;
        private IGenericRepo<Shoes> genericRepoShoes;

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
            RefreshShoes();
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