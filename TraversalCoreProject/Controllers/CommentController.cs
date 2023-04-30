using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _commentManager = new CommentManager(new EfCommentDal());
        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.DestinationId = 3;
            _commentManager.TAdd(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
