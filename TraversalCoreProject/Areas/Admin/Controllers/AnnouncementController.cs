using Business.Abstract;
using Dto.DTOs.AnnouncementDtos;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            List<Announcement> announcements = new List<Announcement>();
            List<AnnouncementListViewModel> models = new List<AnnouncementListViewModel>();
            foreach (var item in announcements)
            {
                AnnouncementListViewModel model = new AnnouncementListViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content
                };
                models.Add(model);
            }
            return View(models);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AddAnnouncementDto addAnnouncementDto)
        {
            return View();
        }
    }
}
