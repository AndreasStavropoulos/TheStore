using System.Collections.ObjectModel;
using System.Linq;
using TheStore.Services;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TheStore.Models
{
    public class Cart : ObservableObject
    {
        private readonly IGenericRepo<Product> productsRepo;
        
        private ObservableCollection<CartItem> cartItems;

        public ObservableCollection<CartItem> CartItems
        {
            get { return cartItems; }
            set
            {
                cartItems = value;
                OnPropertyChanged(nameof(CartItems));
            }
        }

        private double totalAmount;

        public double TotalAmount
        {
            get { return totalAmount; }
            set
            {
                totalAmount = value;
                OnPropertyChanged(nameof(TotalAmount));
            }
        }

        private Cart()
        {            
            productsRepo = new GenericRepo<Product>();
            CartItems = new ObservableCollection<CartItem>();
        }
        private static Cart Instance;

        public static Cart GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Cart();
            }
            return Instance;
        }

        public void AddProduct(Product product)
        {
            var cartItem = CartItems.FirstOrDefault(x => x.Product == product);

            if (cartItem == null)
            {
                CartItem newCartItem = new CartItem
                {
                    Quantity = 1,
                    Product = product
                };
                newCartItem.TotalPrice += newCartItem.Product.Price;
                CartItems.Add(newCartItem);
            }
            else
            {
                cartItem.TotalPrice += cartItem.Product.Price;
                cartItem.Quantity++;
            }
            RefreshTotalAmount();
        }

        public void AddProduct(CartItem cartItem)
        {
            cartItem.TotalPrice += cartItem.Product.Price;
            cartItem.Quantity++;
            RefreshTotalAmount();
        }

        public void SubtractProduct(CartItem cartItem)
        {
            if (cartItem.Quantity <= 1)
            {
                CartItems.Remove(cartItem);                
            }
            else
            {
                cartItem.TotalPrice -= cartItem.Product.Price;
                cartItem.Quantity--;
            }
            RefreshTotalAmount();
        }
        public void SubtractProduct(Product product)
        {
            var cartItem = CartItems.FirstOrDefault(x => x.Product == product);

            if (cartItem.Quantity <= 1)
            {
                CartItems.Remove(cartItem);                
            }
            else
            {
                cartItem.TotalPrice -= cartItem.Product.Price;
                cartItem.Quantity--;
            }
            RefreshTotalAmount();
        }

        public void RefreshTotalAmount()
        {
            TotalAmount = 0;
            foreach (var cartItem in CartItems)
            {
                TotalAmount += cartItem.TotalPrice;
            }
        }
    }
}