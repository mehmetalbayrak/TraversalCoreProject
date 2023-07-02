using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AbstractUoW
{
    public interface IGenericUoWService<T>
    {
        void Add(T entity);
        void Update(T entity);
        void MultiUpdate(List<T> entity);
        T GetById(int id);
    }
}
