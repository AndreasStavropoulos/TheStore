using System;
using System.Collections.Generic;
using System.ComponentModel;
using TheStore.Models;
using TheStore.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheStore.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}