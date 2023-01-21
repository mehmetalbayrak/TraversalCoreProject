using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, new()
    {
        public void Add(T entity)
        {
            using (var context = new Context())
            {
                context.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            using (var context = new Context())
            {
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var context = new Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = new Context())
            {
                context.Update(entity);
            }
        }
    }
}
