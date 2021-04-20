using System;
using TheStore.Services;
using TheStore.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DummyData dummyData = new DummyData();
            //dummyData.FillDb();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}