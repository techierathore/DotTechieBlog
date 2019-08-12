using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Admin/Comments
        public ActionResult UnApprovedList()
        {
            return View();
        }
        public ActionResult AllCommentsList()
        {
            return View();
        }
    }
}