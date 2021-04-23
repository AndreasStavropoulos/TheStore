using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using TheStore.Models;
using TheStore.Services;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    class JeansDetailPageViewModel : BaseViewModel
    {
        private readonly IGenericRepo<Jeans> jeansRepo;
        public ICommand AddToCartCommand { get; }
        private Jeans selectedJeans;

        public Jeans SelectedJeans
        {
            get { return selectedJeans; }
            set
            {
                selectedJeans = value;
                OnPropertyChanged(nameof(SelectedJeans));
            }
        }

        private int jeansId;

        public int JeansId
        {
            get { return jeansId; }
            set
            {
                jeansId = value;
                LoadJeans(value);
            }
        }

        public JeansDetailPageViewModel()
        {
            SelectedJeans = new Jeans();
            jeansRepo = new GenericRepo<Jeans>();
            AddToCartCommand = new Command(AddJeansToCart);
        }

        public void AddJeansToCart()
        {
            Cart.AddProduct(SelectedJeans);
        }

        public void SubtractJeansFromCart()
        {
            Cart.SubtractProduct(SelectedJeans);
        }

        private void LoadJeans(int id)
        {
            try
            {
                var jeans = jeansRepo.FindProductByIdAsync(id);
                SelectedJeans = jeans.Result;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load place");
            }
        }
    }
}
