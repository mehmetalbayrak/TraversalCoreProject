﻿using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class GuideManager : IGuideService
    {
        private IGuideDal _guideDal;

        public GuideManager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public List<Guide> GetAll()
        {
            return _guideDal.GetAll();
        }

        public Guide GetById(int id)
        {
            return _guideDal.GetById(id);
        }

        public void TAdd(Guide entity)
        {
            throw new NotImplementedException();
        }

        public void TChangeToFalseGuide(int id)
        {
            _guideDal.ChangeToFalseGuide(id);
        }

        public void TChangeToTrueGuide(int id)
        {
            _guideDal.ChangeToTrueGuide(id);
        }

        public void TDelete(Guide entity)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Guide entity)
        {
            throw new NotImplementedException();
        }
    }
}
