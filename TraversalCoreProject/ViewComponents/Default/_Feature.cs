using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        HighlightManager highlightManager = new HighlightManager(new EfHighlightDal());
        public IViewComponentResult Invoke()
        {
            var values = highlightManager.GetAll();
            return View(values);
        }
    }
}
