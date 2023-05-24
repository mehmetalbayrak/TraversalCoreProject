using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGuideService : IGenericService<Guide>
    {
        void TChangeToTrueGuide(int id);
        void TChangeToFalseGuide(int id);
    }
}
