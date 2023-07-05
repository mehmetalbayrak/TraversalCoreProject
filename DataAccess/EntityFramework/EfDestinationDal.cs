using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repository;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public List<Destination> GetDestinationWithGuide(int id)
        {
            using (var context = new Context())
            {
                return context.Destinations.Where(x=>x.Id == id).Include(x => x.Guide).ToList();
            }
        }
    }
}
