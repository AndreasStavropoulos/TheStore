using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TheStore.Models;
using System.Windows.Input;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public Cart cart { get; set; }
        public CurrentUser currentUser { get; set; }
        public ICommand GoToUserCommand { get; }
        public ICommand GoToCartCommand { get; }

        private bool isBusy = false;

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        private string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public BaseViewModel()
        {
            cart = Cart.GetInstance();
            currentUser = CurrentUser.GetInstance();
            GoToUserCommand = new Command(GoToUser);
            GoToCartCommand = new Command(GoToCart);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged

        private async void GoToUser()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        private async void GoToCart()
        {
            await Shell.Current.GoToAsync(nameof(CartPage));
        }


    }
}