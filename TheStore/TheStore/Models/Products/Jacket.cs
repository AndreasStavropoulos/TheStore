namespace TheStore.Models
{
    public class Jacket : Product
    {
        public enum Style
        {
            Unknown = 0,
            Bikers = 1, 
            Trucker = 2, 
            Denim = 3, 
            Blouson = 4, 
            Rain = 5
        }

        public enum Size
        {
            Small, Medium, Large, XLarge
        }

        public enum Material
        {
            FauxFur, Wool, Nylon, Cashmere, Leather
        }

        public Style JacketStyle { get; set; }
        public Size JacketSize { get; set; }
        public Material JacketMaterial { get; set; }
    }
}