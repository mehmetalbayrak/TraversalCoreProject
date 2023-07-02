using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        public IActionResult Index()
        {
            var values = destinationManager.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult DestinationDetail(int id)
        {
            ViewBag.Id = id;
            var values = destinationManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetail(Destination destination)
        {
            return View();
        }

    }
}
