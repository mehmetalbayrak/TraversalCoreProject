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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetDestinationById(int id)
        {
            return _commentDal.GetListByFilter(x => x.Id == id).ToList();
        }

        public void TAdd(Comment entity)
        {
            _commentDal.Add(entity);
        }

        public void TDelete(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
