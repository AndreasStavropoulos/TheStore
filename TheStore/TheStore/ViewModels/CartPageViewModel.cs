using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TheStore.Models;
using TheStore.Services;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    public class CartPageViewModel : ProductViewModel
    {
        private ObservableCollection<CartItem> cartItems;

        private CartItemRepo cartItemRepo;

        public ObservableCollection<CartItem> CartItems
        {
            get { return cartItems; }
            set
            {
                cartItems = value;
                OnPropertyChanged(nameof(CartItem));
            }
        }

        public Command<CartItem> SubstractProductCommand { get; set; }
        public Command<CartItem> AddProductCommand { get; set; }

        public CartPageViewModel()
        {
            cartItemRepo = new CartItemRepo();
            SubstractProductCommand = new Command<CartItem>(SubstractProduct);
            AddProductCommand = new Command<CartItem>(AddProduct);

            RefreshCartItems();
        }

        private void AddProduct(CartItem cartItem)
        {
            cart.AddProduct(cartItem);
            RefreshCartItems();
        }

        private void SubstractProduct(CartItem cartItem)
        {
            
        }

        private void RefreshCartItems()
        {
            try
            {
                //List<CartItem> cartItems = await cartItemRepo.GetCartItemsOfActiveUserAsync(currentUser.ActiveUser);
                List<CartItem> cartItems = cart.GetCartList();
                CartItems = new ObservableCollection<CartItem>(cartItems);

            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
    }
}