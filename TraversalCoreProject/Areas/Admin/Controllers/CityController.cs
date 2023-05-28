using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.GetAll());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            destination.CoverImage = "testimage";
            destination.Detail1 = "detail1";
            destination.Detail2 = "detail2";
            destination.Description = "description";
            destination.Image = "image";
            destination.Image2 = "image";
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
        public IActionResult GetById(int id)
        {
            var values = _destinationService.GetById(id);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
        public IActionResult DeleteCity(int id)
        {
           var values = _destinationService.GetById(id);
            _destinationService.TDelete(values);
            return NoContent();
        }
        [HttpPost]
        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var jsonValues = JsonConvert.SerializeObject(destination);
            return Json(jsonValues);
        }
        public static List<CityViewModel> cities = new List<CityViewModel>()
        {
            new CityViewModel()
            {
                Id =1,
                City="Üsküp",
                Country ="Makendonya"
            }
        };
    }
}
