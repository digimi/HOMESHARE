using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace HomeService.Repository
{
    public class CountryRepository : Repository<Country>
    {
        public static IQueryable<Country> Countries()
        {
            using (Repository<Country> context=new Repository<Country>())
            {
                return context.Set();
            }
        }
    }
}
