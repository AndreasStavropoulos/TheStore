using System.Collections.Generic;

namespace TheStore.Models
{
    public interface IJeans
    {
        Jeans.Style JeansStyle { get; set; }
        List<int> Size { get; set; }
    }
}