using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    class HomePageViewModel :BaseViewModel
    {
        private ObservableCollection<Product> catalogue;
        public ObservableCollection<Product> Catalogue
        {
            get { return catalogue; }
            set
            {
                catalogue = value;
                OnPropertyChanged(nameof(Shoes));
            }
        }
        private ObservableCollection<Shoes> shoes;
        public ObservableCollection<Shoes> Shoes
        {
            get { return shoes; }
            set
            {
                shoes = value;
                OnPropertyChanged(nameof(Shoes));
            }
        }
        private ObservableCollection<Jacket> jacket;
        public ObservableCollection<Jacket> Jackets
        {
            get { return jacket; }
            set
            {
                jacket = value;
                OnPropertyChanged(nameof(Jacket));
            }
        }
        private ObservableCollection<TShirt> tShirts;
        public ObservableCollection<TShirt> TShirts
        {
            get { return tShirts; }
            set
            {
                tShirts = value;
                OnPropertyChanged(nameof(TShirts));
            }
        }
        private IGenericRepo<Jeans> genericRepoJeans;
        private IGenericRepo<TShirt> genericRepoTshirts;
        private IGenericRepo<Jacket> genericRepoJackets;
        private IGenericRepo<Shoes> genericRepoShoes;
        public HomePageViewModel()
        {
            genericRepoJeans = new GenericRepo<Jeans>();
            genericRepoTshirts = new GenericRepo<TShirt>();
            genericRepoJackets = new GenericRepo<Jacket>();
            genericRepoShoes = new GenericRepo<Shoes>();
            
        }
       
       
    }
}
