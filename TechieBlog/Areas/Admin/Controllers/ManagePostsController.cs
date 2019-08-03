using BlogEngine.Models;
using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class ManagePostsController : Controller
    {
        // GET: Admin/ManagePosts
        public ActionResult ShowAllPosts()
        {
            return View();
        }
        public ActionResult NewPost()
        {
            Post newPost = new Post() { PostID = 0 };
            return View(newPost);
        }
        [HttpPost]
        public ActionResult NewPost(Post aNewPost)
        {
            var objDataSvc = new BlogSvc();
            var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
            aNewPost.UserID = vCurrUser.UserID;
            bool bResult;
            if (aNewPost.PostID != 0)
            {
                bResult = objDataSvc.SaveNewBlog(aNewPost);
            }
            else { bResult = objDataSvc.UpdateBlog(aNewPost); }
            if (bResult) return RedirectToAction("ShowAllPosts", "ManagePosts");

            ModelState.AddModelError("", "Unable to Save Blog");
            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}