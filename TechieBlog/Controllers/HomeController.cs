using BlogEngine.Models;
using BlogEngine.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var objDataSvc = new BlogSvc();
            IEnumerable<Post> vAllPosts = objDataSvc.GetAllPosts(true, 0);
            return View(vAllPosts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult DetailBlog(long aPostID)
        {
            var objDataSvc = new BlogSvc();
            Post vSelPost = objDataSvc.GetPostForEdit(aPostID);
            return View(vSelPost);
        }
    }
}