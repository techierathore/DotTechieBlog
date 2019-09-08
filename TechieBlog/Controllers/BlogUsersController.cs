using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class BlogUsersController : Controller
    {
        public ActionResult UsersList()
        {
            return View();
        }
        public ActionResult UserProfile()
        {
            return View();
        }
        public ActionResult UserEvents()
        {
            return View();
        }
        public ActionResult AddEvent()
        {
            return View();
        }
    }
}