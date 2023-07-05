using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = destinationManager.GetAll();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> DestinationDetail(int id)
        {
            ViewBag.Id = id;
            var values = destinationManager.GetDestinationWithGuide(id);
            var appUserId = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.AppUserId = appUserId.Id;
            return View(values);
        }
        [HttpPost]
        public IActionResult DestinationDetail(Destination destination)
        {
            return View();
        }

    }
}
