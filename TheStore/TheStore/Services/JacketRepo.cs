using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheStore.Models;

namespace TheStore.Services
{
    internal class JacketRepo
    {
        // Fake database
        
        private List<Jacket> jackets;

        public JacketRepo()
        {
            //jackets = GetDummyJacket();
            //TempSaveDummyData();
        }


        private List<Jacket> GetDummyJacket()
        {
            jackets = new List<Jacket>
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


        private async void TempSaveDummyData()
        {

            foreach (var jacket in jackets)
            {
                await SaveJacket(jacket); 
            }
        }


        //------------------------


        public async Task<List<Jacket>> GetAllJacketsAsync()
        {
            using (var dbContext = new TheStoreContext())
            {
                return await dbContext.jackets.ToListAsync();
            }
        }


        public async Task SaveJacket(Jacket jacket)
        {
            using (var dbContext = new TheStoreContext())
            {
                if (jacket.Id == 0)
                {
                    await dbContext.jackets.AddAsync(jacket);
                }
                else
                {
                    dbContext.jackets.Update(jacket);
                }
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<Jacket> GetJacketByID(int id)
        {
            using (var dbContext = new TheStoreContext())
            {
                var jacket = await dbContext.jackets.FindAsync(id);
                return jacket;
            }
        }

        public async Task DeleteJacket(Jacket jacket)
        {
            using (var dbContext = new TheStoreContext())
            {
                dbContext.Remove(jacket);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}