using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TraversalCoreProject.ViewComponents.Comment
{
    public class _AddComment : ViewComponent
    {
        //CommentManager _commentManager = new CommentManager(new EfCommentDal());
        //[HttpGet]
        public IViewComponentResult Invoke()
        {
            return View();
        }
        //[HttpPost]
        //public IViewComponentResult Invoke(Entity.Concrete.Comment comment)
        //{
        //    comment.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //    _commentManager.TAdd(comment);
        //    return View();
        //}
    }
}
