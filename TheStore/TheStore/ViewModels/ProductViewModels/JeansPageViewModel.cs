using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels.ProductViewModels
{
    internal class JeansPageViewModel : BaseViewModel
    {
        private ObservableCollection<Jeans> jeans;
        private IGenericRepo<Jeans> genericRepoJeans;

        public ObservableCollection<Jeans> Jeans
        {
            get { return jeans; }
            set
            {
                jeans = value;
                OnPropertyChanged(nameof(Jacket));
            }
        }

        public JeansPageViewModel()
        {
            genericRepoJeans = new GenericRepo<Jeans>();
            RefreshJackets();
        }

        private async void RefreshJackets()
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
    }
}