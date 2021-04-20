using System;
using System.Collections.Generic;
using System.Text;

namespace TheStore.Models
{
    public class Shoes : Product
    {
        public enum Style
        {
            Sneakers, Boots, Classic, FlipFlops
        }

        public enum Material
        {
            FauxFur, Wool, Nylon, Cashmere, Leather
        }

        //public List<int> Size { get; set; }

        public Style ShoeStyle { get; set; }
        public Material ShoeMaterial { get; set; }
    }
}