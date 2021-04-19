using System.Collections.Generic;

namespace TheStore.Models
{
    public interface IShoes
    {
        Shoes.Material ShoeMaterial { get; set; }
        Shoes.Style ShoeStyle { get; set; }
        List<int> Size { get; set; }
    }
}