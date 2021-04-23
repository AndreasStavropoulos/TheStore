using System;
using System.Collections.Generic;
using TheStore.ViewModels;
using TheStore.Views;
using Xamarin.Forms;

namespace TheStore
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
            Routing.RegisterRoute(nameof(JeansPage), typeof(JeansPage));
            Routing.RegisterRoute(nameof(TShirtPage), typeof(TShirtPage));
            Routing.RegisterRoute(nameof(JacketPage), typeof(JacketPage));
            Routing.RegisterRoute(nameof(ShoesPage), typeof(ShoesPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(JacketDetailPageViewModel), typeof(JacketDetailPageViewModel));
            Routing.RegisterRoute(nameof(JacketDetailPage), typeof(JacketDetailPage));
            Routing.RegisterRoute(nameof(JeansDetailPage), typeof(JeansDetailPage));
            Routing.RegisterRoute(nameof(JeansDetailPageViewModel), typeof(JeansDetailPageViewModel));
        }
    }
}