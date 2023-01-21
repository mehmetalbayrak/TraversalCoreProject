using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManager _subAboutManager = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = _subAboutManager.GetAll();
            return View(values);
        }
    }
}
