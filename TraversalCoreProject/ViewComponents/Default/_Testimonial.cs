using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = _testimonialManager.GetAll();
            return View(values);
        }
    }
}
