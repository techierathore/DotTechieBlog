using BlogEngine.Models;
using BlogEngine.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class ManagePostsController : Controller
    {
        // GET: Admin/ManagePosts
        public ActionResult ShowAllPosts()
        {
            var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
            var objDataSvc = new BlogSvc();
            IEnumerable<Post> vAllPosts;
            if (vCurrUser.Role == Constants.Admin)
            {
                vAllPosts = objDataSvc.GetAllPosts(true,0);
            }
            else { vAllPosts = objDataSvc.GetAllPosts(false, vCurrUser.UserID); }
           
            return View(vAllPosts);
        }

        public ActionResult EditPost(long  aPostID)
        {
            var objDataSvc = new BlogSvc();
            Post vPost = objDataSvc.GetPostForEdit(aPostID);
            if (vPost == null)
            {
                return HttpNotFound();
            }
            //Send you to NewPost.chtml to save copy same page 
            return View("NewPost", vPost);
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
            if (aNewPost.PostID == 0)
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