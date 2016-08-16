using HomeService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Repository
{
    public static class ResidenceRepository
    {
        public static async Task<List<Residence>> GetAllAsync()
        {
            using (Repository<Residence> context = new Repository<Residence>())
            {
                return await context.Set().Include(r => r.Pictures).Include(r => r.Country).Include(r => r.Member).ToListAsync();
            }
        }

        public static async Task Add(Residence residence)
        {
            using (Repository<Residence> context=new Repository<Residence>())
            {
                await context.InsertAsync(residence);
            }
        }

        public static async Task<Residence> GetByIdAsync(int id)
        {
            using (Repository<Residence> context=new Repository<Residence>())
            {
                return await context.GetByIdAsync(id);
            }
        }
    }
}
