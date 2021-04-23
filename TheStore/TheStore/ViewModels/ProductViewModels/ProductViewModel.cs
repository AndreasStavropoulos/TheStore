using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TheStore.Models;
using TheStore.Services;

namespace TheStore.ViewModels
{
    public class ProductViewModel<T> : BaseViewModel where T : Product
    {
        
        //private readonly IGenericRepo<T> genericRepoProducts;

        //private ObservableCollection<T> products;

        //public ObservableCollection<T> Products
        //{
        //    get { return products; }
        //    set
        //    {
        //        products = value;
        //        OnPropertyChanged(nameof(Products));
        //    }
        //}
        //public ProductViewModel()
        //{
        //    genericRepoProducts = new GenericRepo<T>();
        //    RefreshProducts();
        //}
        //private async void RefreshProducts()
        //{
        //    try
        //    {
        //        List<T> products = await genericRepoProducts.GetAllProductsAsync();
        //        var Products = new ObservableCollection<T>(products);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.Write(e);
        //    }
        //}
    }
}