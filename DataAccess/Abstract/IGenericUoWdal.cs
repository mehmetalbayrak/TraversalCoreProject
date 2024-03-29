﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IGenericUoWdal<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void MultiUpdate(List<T> entity);
        T GetById(int id);
    }
}
