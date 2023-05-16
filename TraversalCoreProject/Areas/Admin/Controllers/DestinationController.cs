using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = _destinationManager.GetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationManager.TAdd(destination);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult DeleteDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteDestination(int id)
        {
            var destination = _destinationManager.GetById(id);
            _destinationManager.TDelete(destination);
            return View();
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var destination = _destinationManager.GetById(id);
            return View(destination);
        }
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationManager.TUpdate(destination);
            return RedirectToAction("Index", "Destination", new {area ="Admin"});
        }

    }
}
