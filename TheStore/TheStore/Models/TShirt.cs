using System;
using System.Collections.Generic;
using System.Text;

namespace TheStore.Models
{

    public class TShirt : Product, ITShirt
    {
        public enum Size
        {
            Small, Medium, Large, XLarge
        }

        public enum Style
        {
            LongSleeve, ShortSleeve, DressShirt, Chambray
        }

        public Size TShirtSize { get; set; }
        public Style TShirtStyle { get; set; }

    }
}
