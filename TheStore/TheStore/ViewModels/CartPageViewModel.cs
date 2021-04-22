using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    public class CartPageViewModel : BaseViewModel
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

        public CartPageViewModel()
        {
            cartItemRepo = new CartItemRepo();

            RefreshCartItems();
        }

        private async void RefreshCartItems()
        {
            try
            {
                List<CartItem> cartItems = await cartItemRepo.GetCartItemsOfActiveUserAsync(currentUser.ActiveUser);
                CartItems = new ObservableCollection<CartItem>(cartItems);
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }
        }
    }
}