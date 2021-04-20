using System.Collections.Generic;
using TheStore.Models;

namespace TheStore.Services
{
    internal class DummyData
    {
        private IGenericRepo<Jacket> genericRepoJackets;
        private IGenericRepo<Shoes> genericRepoShoes;

        public DummyData()
        {
            genericRepoShoes = new GenericRepo<Shoes>();
            genericRepoJackets = new GenericRepo<Jacket>();
        }

        public async void FillDb()
        {
            List<Shoes> shoes = GetShoes();
            foreach (var shoe in shoes)
            {
                await genericRepoShoes.SaveProductAsync(shoe);
            }

            List<Jacket> jackets = GetJackets();
            foreach (var jacket in jackets)
            {
                await genericRepoJackets.SaveProductAsync(jacket);
            }
        }

        private List<Shoes> GetShoes()
        {
            List<Shoes> shoes = new List<Shoes>
            {
                new Shoes
                {
                    Id = 0,
                    Name = "adidas",
                    Price = 12.5,
                    ImgUrl = "shoes1.png"
                },

                new Shoes
                {
                    Id = 0,
                    Name = "nike",
                    Price = 15.5,
                    ImgUrl = "shoe2.png"
                }
            };
            return shoes;
        }

        private List<Jacket> GetJackets()
        {
            List<Jacket> jackets = new List<Jacket>
            {
                new Jacket
                {
                    Id = 0,
                    Name = "blazer",
                    Description = "this is a jacket",
                    Price = 12.55,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "blazer.jpg",
                    JacketStyle = Jacket.Style.Blouson,
                    JacketSize = Jacket.Size.Small,
                    JacketMaterial = Jacket.Material.Leather,
                },
                new Jacket
                {
                    Id = 0,
                    Name = "parka",
                    Description = "this is a 2nd jacket",
                    Price = 125.55,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "blazer.jpg",
                    JacketStyle = Jacket.Style.Denim,
                    JacketSize = Jacket.Size.Large,
                    JacketMaterial = Jacket.Material.Nylon,
                }
            };
            return jackets;
        }
    }
}