namespace TheStore.Models
{
    public class TShirt : Product
    {
        public enum Size

        {
            TU = 0,
            Small, 
            Medium, 
            Large, 
            XLarge
        }

        public enum Style
        {
            Unkown = 0,
            LongSleeve, 
            ShortSleeve, 
            DressShirt, 
            Chambray
        }

        public Size TShirtSize { get; set; }
        public Style TShirtStyle { get; set; }
    }
}