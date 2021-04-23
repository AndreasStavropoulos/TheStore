namespace TheStore.Models
{
    public class Jeans : Product
    {
        public enum Style
        {
            Skinny, Baggy, BootCut, Straight
        }

        //public enum Size
        //{
        //    Small,
        //    Medium,
        //    Large,
        //    XLarge
        //}

        public Style JeansStyle { get; set; }
        //public Size JeansSize { get; set; }
    }
}