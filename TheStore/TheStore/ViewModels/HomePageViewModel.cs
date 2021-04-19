using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        private ObservableCollection<Jacket> jackets;
        private JacketRepo jacketRepo;

        public ObservableCollection<Jacket> Jackets
        {
            get { return jackets; }
            set
            {
                jackets = value;
                OnPropertyChanged(nameof(Jackets));
            }
        }

        public HomePageViewModel()
        {
            jacketRepo = new JacketRepo();
            RefreshJackets();
        }

        private async void RefreshJackets()
        {
            try
            {
                List<Jacket> jackets = await jacketRepo.GetAllJacketsAsync();
                Jackets = new ObservableCollection<Jacket>(jackets);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
    }
}