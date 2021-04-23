namespace TheStore.Models
{
    public class CartItem : ObservableObject
    {
        public int Id { get; set; }
        public int ProductId { get; set; }        

        public int UserId { get; set; }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public User User { get; set; }
        public Product Product { get; set; }
    }
}