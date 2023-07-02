using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AbstractUoW
{
    public interface IAccountService:IGenericUoWService<Account>
    {
    }
}
