using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    class JeansPageViewModel :BaseViewModel
    {
        private ObservableCollection<Jeans> jeans;
        private readonly IGenericRepo<Jeans> genericRepoJeans;

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
            RefreshJeans();
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
    }
}
