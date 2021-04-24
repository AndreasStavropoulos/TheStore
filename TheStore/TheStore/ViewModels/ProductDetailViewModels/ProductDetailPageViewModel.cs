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
    [QueryProperty(nameof(ProductId), nameof(ProductId))]
    public class ProductDetailPageViewModel : BaseViewModel
    {
        private readonly IGenericRepo<Product> productRepo;
        public ICommand AddToCartCommand { get; }
        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { 
                productId = value;
                LoadProduct(value);
            }
        }

        public ProductDetailPageViewModel()
        {
            //SelectedProduct = new Product();
            productRepo = new GenericRepo<Product>();
            AddToCartCommand = new Command(AddProductToCart);
        }

        private async void AddProductToCart()
        {
            Cart.AddProduct(SelectedProduct);
            await Shell.Current.GoToAsync("..");
        }

        private void LoadProduct(int id)
        {
            try
            {
                var product = productRepo.FindProductByIdAsync(id);
                SelectedProduct = product.Result;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to load place");
            }
        }
    }
}
