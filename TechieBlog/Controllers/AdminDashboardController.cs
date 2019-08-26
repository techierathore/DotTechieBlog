using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class AdminDashboardController : Controller
    {
        public ActionResult AdminHome()
        {
            var objDataSvc = new AdminHomeSvc();
            return View(objDataSvc.GetAdminCounts());
        }
        public ActionResult ShowReports()
        {
            return View();
        }
    }
}