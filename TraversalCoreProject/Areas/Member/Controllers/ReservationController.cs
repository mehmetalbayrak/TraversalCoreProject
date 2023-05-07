using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new EfDestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new EfReservationDal());
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationManager.GetListWithReservationByAccepted(user.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationManager.GetListWithReservationByPrevious(user.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = _reservationManager.GetListWithReservationByWaitApproval(user.Id);
            return View(valuesList);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in _destinationManager.GetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.Id.ToString()
                                           }).ToList();
            ViewBag.Values = values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.AppUserId = 3;
            reservation.Status = "Onay bekliyor";
            _reservationManager.TAdd(reservation);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
