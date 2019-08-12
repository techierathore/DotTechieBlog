using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Home
        public ActionResult Home()
        {
            var objDataSvc = new AdminHomeSvc();
            return View(objDataSvc.GetAdminCounts());
        }
    }
}