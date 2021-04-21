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
        private IUserRepo userRepo;
        private CartItemRepo cartItemRepo;

        public DummyData()
        {
            genericRepoShoes = new GenericRepo<Shoes>();
            genericRepoJackets = new GenericRepo<Jacket>();
            genericRepoTshirt = new GenericRepo<TShirt>();
            genericRepoJeans = new GenericRepo<Jeans>();
            userRepo = new UserRepo();
            cartItemRepo = new CartItemRepo();
        }


        public async void FillDb()
        {
            List<Jacket> jackets = GetJackets();
            foreach (var jacket in jackets)
            {
                await genericRepoJackets.SaveProductAsync(jacket);
            }

            List<Shoes> shoes = GetShoes();
            foreach (var shoe in shoes)
            {
                await genericRepoShoes.SaveProductAsync(shoe);
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

            List<User> users = GetUsers();
            foreach (var user in users)
            {
                await userRepo.SaveUserAsync(user);
            }

            List<CartItem> cartItems = GetCartItems();
            foreach (var cartitem in cartItems)
            {
                await cartItemRepo.SaveCartItemAsync(cartitem);
            }

        }

        private List<User> GetUsers()
        {
            List<User> users = new List<User>
            {
                new User
            {

                Email = "andreas@store.be",
                Name = "Andreas",
                Password = "1234",
                IsAdmin = false
            },

                 new User
            {
                
                Email = "emma@store.be",
                Name = "Emma",
                Password = "12345",
                IsAdmin = false
            },

            };
            return users;
        }

        private List<Shoes> GetShoes()
        {
            List<Shoes> shoes = new List<Shoes>
            {
                new Shoes
                {
                    
                    Name = "Sneaker",
                    Price = 16.84,
                    ImgUrl = "sneaker.jpg",
                    IsInStock = true,
                    Color = Color.Gray,
                    Description = "Mannen Casual Schoenen 2021 Mode Sneakers Mannen Schoenen Nieuwe Tennis Schoenen Mannen Sneakers Volwassen Schoenen Trainers Mannen Vulcaniseer Schoenen",
                    ShoeMaterial = Shoes.Material.Leather,
                    ShoeStyle = Shoes.Style.Sneakers
                },

                new Shoes
                {
                    
                    Name = "Boots",
                    Price = 79.99,
                    ImgUrl = "boots.jpg",
                    IsInStock = true,
                    Color = Color.Cognac,
                    Description = "Boots jfwrussel JACK & JONES cognac",
                    ShoeMaterial = Shoes.Material.Leather,
                    ShoeStyle = Shoes.Style.Boots
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
                    
                    Name = "blazer",
                    Description = "Linen, wool and silk hopsack deconstructed jacket with patch pockets",
                    Price = 2550.00,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "blazer.jpg",
                    JacketStyle = Jacket.Style.Blouson,
                    JacketSize = Jacket.Size.Small,
                    JacketMaterial = Jacket.Material.Wool,
                },
                new Jacket
                {
                    
                    Name = "parka",
                    Description = "SNOWDON PEAK FISHTAIL PARKA VOOR HEREN IN GROEN",
                    Price = 383.99,
                    IsInStock = true,
                    Color = Color.Green,
                    ImgUrl = "parka.jpg",
                    JacketStyle = Jacket.Style.Rain,
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
                    
                    Name = "Mo-How-Zeg",
                    Description = "Mo joeng toch, mo how zeg … t’is nie te gelovn! Zukke toffen shirt dat hier verkocht wordt ;-). Haal hem nu in huis!",
                    Price = 22.55,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "mohowseg_tee.jpg",
                    TShirtSize = TShirt.Size.Large,
                    TShirtStyle = TShirt.Style.DressShirt
                },
                new TShirt
                {
                    
                    Name = "v-neck tshirt",
                    Description = "De fijne T-shirts met V-hals zijn nu ook verkrijgbaar in de kleur army! De bamboe shirts zitten geweldig door de zijdezachte stof en zijn te dragen onder een overhemd, maar ook als casual T-shirt. Voel je gegarandeerd de hele dag fris door de fijne eigenschappen van bamboe!",
                    Price = 5.55,
                    IsInStock = true,
                    Color = Color.Blue,
                    ImgUrl = "v_neck_tee.jpg",
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
                    Name = "Skinny",
                    Description = "Urban Classics heren skinny jeans Ripped - blauw",
                    Price = 41.59,
                    IsInStock = true,
                    Color = Color.Pink,
                    ImgUrl = "skinny_jeans.jpg",
                    JeansStyle = Jeans.Style.Skinny
                },
                new Jeans
                {
                    
                    Name = "Straight",
                    Description = "De jeans die niet mag ontbreken in u garderobe? Dat is ongetwijfeld de 501 van Levi''s® ! Deze straight leg jeans staat jong en oud dankzij deze universele fit met rechte broekpijpen over de hele lengte. Het grootste voordeel is dat je de broek overal mee kan matchen. Of je nu een T-shirt met print en een paar sneakers of en hemd met geklede schoenen wil dragen het kan allemaal.",
                    Price = 89.95,
                    IsInStock = true,
                    Color = Color.Blue,
                    ImgUrl = "straight_jeans.jpg",
                    JeansStyle = Jeans.Style.Straight
                }
            };
            return jeans;
        }

        private List<CartItem> GetCartItems()
        {
            List<CartItem> cartItems = new List<CartItem>
            {
                new CartItem
                {
                    
                    Quantity = 2,
                    ProductId = 2,
                    UserId =1
                },
                new CartItem
                {
                    
                    Quantity = 3,
                    ProductId = 2,
                    UserId =1
                },
                new CartItem
                {

                    Quantity = 3,
                    ProductId = 2,
                    UserId =2
                }
            };
            return cartItems;
        }
    }
}