using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HighlightManager : IHighlightService
    {
        IHighlightDal _highlightDal;

        public HighlightManager(IHighlightDal highlightDal)
        {
            _highlightDal = highlightDal;
        }

        public List<Highlight> GetAll()
        {
            return _highlightDal.GetAll();
        }

        public Highlight GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Highlight entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Highlight entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Highlight entity)
        {
            throw new NotImplementedException();
        }
    }
}
