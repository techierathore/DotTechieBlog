using BlogEngine.Models;
using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? PageNo)
        {
            var objDataSvc = new BlogHomeSvc();
            var vAllPosts = objDataSvc.GetAllBlogs(PageNo);
            return View(vAllPosts);
        }
        public ActionResult DetailBlog(long aPostID)
        {
            var objDataSvc = new BlogSvc();
            Post vSelPost = objDataSvc.GetPostForEdit(aPostID);
            return View(vSelPost);
        }

        public ActionResult Counts()
        {
            var objDataSvc = new BlogHomeSvc();
            Post vSelPost = objDataSvc.GetBlogForCounts();
            return View(vSelPost);
        }
        public ActionResult RecentBlogs()
        {
            var objDataSvc = new BlogHomeSvc();
            var vSelPost = objDataSvc.GetRecentBlogs();            
            return View(vSelPost);
        }
        public ActionResult Tags()
        {
            var objDataSvc = new BlogSvc();
            var vTags = objDataSvc.GetAllTags();
            return View(vTags);
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
    }
}