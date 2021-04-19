using System.ComponentModel;
using TheStore.ViewModels;
using Xamarin.Forms;

namespace TheStore.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}