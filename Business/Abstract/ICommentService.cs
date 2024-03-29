﻿using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        public List<Comment> GetDestinationById(int id);
        public List<Comment> GetListCommentWithDestination();
        public List<Comment> GetListCommentWithDestinationAndUser(int id);
    }
}
