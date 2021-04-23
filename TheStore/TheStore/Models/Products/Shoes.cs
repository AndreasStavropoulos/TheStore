namespace TheStore.Models
{
    public class Shoes : Product
    {
        public enum Style
        {
            Unknown = 0,
            Sneakers, 
            Boots, 
            Classic, 
            FlipFlops
        }

        public enum Material
        {
            Unknown = 0,
            FauxFur, 
            Wool, 
            Nylon, 
            Cashmere, 
            Leather
        }

        //public List<int> Size { get; set; }

        public Style ShoeStyle { get; set; }
        public Material ShoeMaterial { get; set; }
    }
}