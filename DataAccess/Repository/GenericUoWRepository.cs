using DataAccess.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GenericUoWRepository<T> : IGenericUoWdal<T> where T : class
    {
        private readonly Context _context;

        public GenericUoWRepository(Context context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
           _context.Add(entity);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void MultiUpdate(List<T> entity)
        {
            _context.UpdateRange(entity);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
