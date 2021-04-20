using System;
using System.Collections.Generic;
using System.Text;

namespace TheStore.Models
{
    public class Jacket : Product
    {
        public enum Style
        {
            Bikers, Trucker, Denim, Blouson
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