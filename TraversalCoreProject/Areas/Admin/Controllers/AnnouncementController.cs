using AutoMapper;
using Business.Abstract;
using DocumentFormat.OpenXml.Office2010.Excel;
using Dto.DTOs.AnnouncementDtos;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.GetAll());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AddAnnouncementDto addAnnouncementDto)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Title = addAnnouncementDto.Title,
                    Content = addAnnouncementDto.Content,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
            }
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.GetById(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<UpdateAnnouncementDto>(_announcementService.GetById(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(UpdateAnnouncementDto updateAnnouncementDto)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement()
                {
                    Id = updateAnnouncementDto.Id,
                    Title = updateAnnouncementDto.Title,
                    Content = updateAnnouncementDto.Content,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
            }
            return RedirectToAction("Index");
        }
    }
}
