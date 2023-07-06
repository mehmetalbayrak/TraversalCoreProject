using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class ContactController : Controller
    {
        ContacUsManager contacUsManager = new ContacUsManager(new EfContactUsDal());
        public IActionResult Index()
        {
            return View();
        }
    }
}
