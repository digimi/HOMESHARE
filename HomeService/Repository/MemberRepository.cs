using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Repository
{
    public class MemberRepository:Repository<Member>
    {
        public static IEnumerable Members()
        {
            using (Repository<Member> context = new Repository<Member>())
            {
                return context.Set();
            }
        }
    }
}
