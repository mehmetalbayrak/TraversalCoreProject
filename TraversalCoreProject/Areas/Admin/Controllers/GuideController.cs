﻿using Business.Abstract;
using Business.Validation;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.GetAll();
            return View(values);
        }
        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index", "Guide", new { area = "Admin" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [Route("EditGuide/{id}")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.GetById(id);
            return View(values);
        }
        [Route("EditGuide/{id}")]
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
