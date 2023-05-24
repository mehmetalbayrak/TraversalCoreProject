﻿using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repository;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public void ChangeToFalseGuide(int id)
        {
            using (var context = new Context())
            {
                var values = context.Guides.Find(id);
                values.Status = false;
                context.Update(values);
                context.SaveChanges();
            }
        }

        public void ChangeToTrueGuide(int id)
        {
            using (var context = new Context())
            {
                var values = context.Guides.Find(id);
                values.Status = true;
                context.Update(values);
                context.SaveChanges();
            }
        }
    }
}
