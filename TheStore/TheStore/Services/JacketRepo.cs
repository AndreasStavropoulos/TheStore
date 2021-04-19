using System;
using System.Collections.Generic;
using System.Text;
using TheStore.Models;

namespace TheStore.Services
{
    internal class JacketRepo
    {
        private List<Jacket> jackets;

        public JacketRepo()
        {
            jackets = GetDummyJacket();
        }

        private List<Jacket> GetDummyJacket()
        {
            jackets = new List<Jacket>
            {
                new Jacket
                {
                    Id = 1,
                    Name = "blazer",
                    Description = "this is a jacket",
                    Price = 12.55,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "iets.png",
                    JacketStyle = Jacket.Style.Blouson,
                    JacketSize = Jacket.Size.Small,
                    JacketMaterial = Jacket.Material.Leather,
                },
                new Jacket
                {
                    Id = 2,
                    Name = "parka",
                    Description = "this is a 2nd jacket",
                    Price = 125.55,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "ietsandrs.png",
                    JacketStyle = Jacket.Style.Denim,
                    JacketSize = Jacket.Size.Large,
                    JacketMaterial = Jacket.Material.Nylon,
                }
            };
            return jackets;
        }

        public List<Jacket> GetJackets()
        {
            return jackets;
        }

        public Jacket GetJacketById(int id)
        {
            return jackets.Find(x => x.Id == id);
        }

        public void UpdateJacket()
        {
        }
    }
}