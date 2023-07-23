using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using DataAccess.EntityFramework;
using Dto.DTOs.ContactDtos;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Index(SendMessageDto message)
        {
            if (ModelState.IsValid)
            {
                _contactService.TAdd(new ContactUs()
                {
                    Body= message.Body,
                    Mail = message.Mail,
                    MessageDate= Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    Name = message.Name,
                    Subject= message.Subject,
                    Status =true
                });
                return RedirectToAction("Index");
            }
            return View(message);
        }
    }
}
