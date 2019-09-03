using BlogEngine.Services;
using BlogEngine.ViewModels;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? PageNo)
        {
            var objDataSvc = new BlogHomeSvc();
            var vAllPosts = objDataSvc.GetAllBlogs(PageNo);
            if (vAllPosts == null) return View();
            return View(vAllPosts);
        }
        public ActionResult DetailBlog(long aPostID)
        {
            var objDataSvc = new BlogHomeSvc();
            DisplayBlog vSelPost = objDataSvc.GetDisplayBlog(aPostID);
            return View(vSelPost);
        }
        public ActionResult SaveComment()
        {
            var vComment = new CommentMessage();
            return View(vComment);
        }
        [HttpPost]
        public ActionResult SaveComment(DisplayBlog BlogWithComment)
        {
            if (!ModelState.IsValid) { return null; }
            var objDataSvc = new CommentSvc();
            string sMessage;
            if (objDataSvc.SaveComment(BlogWithComment.NewComment))
            {
                sMessage = "Thank You for your valuable comment, It will be published on approval from Moderator.";
            }
            else sMessage = "Unable to Save new comment";
            var vReturnObj = new CommentMessage() {
                 GivenBy = BlogWithComment.NewComment.GivenBy,
                 Message = sMessage,
                 PostID = BlogWithComment.NewComment.PostID,
                 PostTitle = BlogWithComment.BlogPost.Title
            };
            // If we got this far, something failed, redisplay form
            return View("SaveComment", vReturnObj);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Podcast()
        {
            return View();
        }
        public ActionResult Speaking()
        {
            return View();
        }
    }
}