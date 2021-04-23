using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    public class TShirtPageViewModel : BaseViewModel
    {
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