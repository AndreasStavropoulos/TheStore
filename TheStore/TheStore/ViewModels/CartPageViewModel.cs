using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TheStore.Models;

namespace TheStore.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        private ObservableCollection<CartItem> cartItems;

        public ObservableCollection<CartItem> CartItems
        {
            get { return cartItems; }
            set
            {
                cartItems = value;
                OnPropertyChanged(nameof(CartItem));
            }
        }
    }
}

