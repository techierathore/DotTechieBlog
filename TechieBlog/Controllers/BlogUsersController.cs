using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class BlogUsersController : Controller
    {
        public ActionResult UsersList()
        {
            return View();
        }
    }
}