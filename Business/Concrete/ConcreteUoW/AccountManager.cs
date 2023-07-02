using Business.Abstract.AbstractUoW;
using DataAccess.Abstract;
using DataAccess.UnitOfWork;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ConcreteUoW
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUoWDal _uowDal;

        public AccountManager(IAccountDal accountDal, IUoWDal uowDal)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
        }

        public void Add(Account entity)
        {
            _accountDal.Add(entity);
            _uowDal.Save();
        }

        public Account GetById(int id)
        {
            return _accountDal.GetById(id);
        }

        public void MultiUpdate(List<Account> entity)
        {
            _accountDal.MultiUpdate(entity);
            _uowDal.Save();
        }

        public void Update(Account entity)
        {
            _accountDal.Update(entity);
            _uowDal.Save();
        }
    }
}
