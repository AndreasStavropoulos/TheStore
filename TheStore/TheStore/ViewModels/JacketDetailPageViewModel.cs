using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TheStore.Models;
using TheStore.Services;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    [QueryProperty(nameof(JacketId), nameof(JacketId))]
    public class JacketDetailPageViewModel: BaseViewModel
    {
        private IGenericRepo<Jacket> jacketRepo;

        private Jacket selectedJacket;

        public Jacket SelectedJacket
        {
            get { return selectedJacket; }
            set
            {
                selectedJacket = value;
                OnPropertyChanged(nameof(SelectedJacket));
            }
        }

        private int jacketId;

        public int JacketId
        {
            get { return jacketId; }
            set
            {
                jacketId = value;
                LoadJacket(value);
            }
        }

        public JacketDetailPageViewModel()
        {
            SelectedJacket = new Jacket();
            jacketRepo = new GenericRepo<Jacket>();
        }

        private void LoadJacket(int id)
        {
            try
            {
                var jacket = jacketRepo.FindProductByIdAsync(id);
                SelectedJacket = jacket.Result;
            }
            catch (Exception)
            {

                Debug.WriteLine("Failed to load place");
            }
        }



    }
}
