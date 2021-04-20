using System.Collections.Generic;

namespace TheStore.Models
{
    public class Jeans : Product
    {
        public enum Style
        {
            Skinny, Baggy, BootCut, Straight
        }

        public List<int> Size { get; set; }

        public Style JeansStyle { get; set; }
    }
}