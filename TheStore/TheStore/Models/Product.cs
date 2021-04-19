using System;
using System.Collections.Generic;
using System.Text;

namespace TheStore.Models
{
    public enum Color
    {
        Pink, White, Black, Red, Green, Blue, Yellow
    }

    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsInStock { get; set; }
        public Color Color { get; set; }
        public string ImgUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}