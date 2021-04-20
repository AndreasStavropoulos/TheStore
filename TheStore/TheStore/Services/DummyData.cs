using System.Collections.Generic;
using TheStore.Models;

namespace TheStore.Services
{
    internal class DummyData
    {
        private IGenericRepo<Jacket> genericRepoJackets;
        private IGenericRepo<Shoes> genericRepoShoes;
        private IGenericRepo<TShirt> genericRepoTshirt;
        private IGenericRepo<Jeans> genericRepoJeans;

        public DummyData()
        {
            genericRepoShoes = new GenericRepo<Shoes>();
            genericRepoJackets = new GenericRepo<Jacket>();
            genericRepoTshirt = new GenericRepo<TShirt>();
            genericRepoJeans = new GenericRepo<Jeans>();
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

            List<TShirt> tshirts = GetTShirts();
            foreach (var tshirt in tshirts)
            {
                await genericRepoTshirt.SaveProductAsync(tshirt);
            }

            List<Jeans> jeans = GetJeans();
            foreach (var jean in jeans)
            {
                await genericRepoJeans.SaveProductAsync(jean);
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

        private List<TShirt> GetTShirts()
        {
            List<TShirt> tshirts = new List<TShirt>
            {
                new TShirt
                {
                    Id = 0,
                    Name = "simple",
                    Description = "this is a tshirt",
                    Price = 2.55,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "tshirt1.jpg",
                    TShirtSize = TShirt.Size.Large,
                    TShirtStyle = TShirt.Style.DressShirt
                },
                new TShirt
                {
                    Id = 0,
                    Name = "v tshirt",
                    Description = "this is also a t-shirt",
                    Price = 5.55,
                    IsInStock = true,
                    Color = Color.Blue,
                    ImgUrl = "tshirt2.jpg",
                    TShirtSize = TShirt.Size.Small,
                    TShirtStyle = TShirt.Style.LongSleeve
                }
            };
            return tshirts;
        }

        private List<Jeans> GetJeans()
        {
            List<Jeans> jeans = new List<Jeans>
            {
                new Jeans
                {
                    Id = 0,
                    Name = "Skinny",
                    Description = "this is a jeans",
                    Price = 32.55,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "jeans.jpg",
                    JeansStyle = Jeans.Style.Skinny
                },
                new Jeans
                {
                    Id = 0,
                    Name = "Straight",
                    Description = "this is also a jeans",
                    Price = 25.95,
                    IsInStock = true,
                    Color = Color.Blue,
                    ImgUrl = "jeans.jpg",
                    JeansStyle = Jeans.Style.Straight
                }
            };
            return jeans;
        }
    }
}