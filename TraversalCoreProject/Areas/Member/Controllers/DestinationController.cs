using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.GetAll();
            return View(values);
        }
        public IActionResult GetCitiesSearchByName(string search)
        {
            ViewData["CurrentFilter"] = search;
            var values = from x in destinationManager.GetAll() select x;
            if (!string.IsNullOrEmpty(search))
            {
                values = values.Where(y => y.City.Contains(search));
            }
            return View(values.ToList());
        }
    }
}
