using Business.Concrete;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                ViewBag.Destination = context.Destinations.Count().ToString();
                ViewBag.Guides = context.Guides.Count();
                ViewBag.Customer = "285";

            }
            return View();
        }
    }
}
