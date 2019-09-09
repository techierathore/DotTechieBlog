using BlogEngine.Models;
using BlogEngine.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class BlogPostsController : Controller
    {
        public ActionResult ShowAllPosts()
        {
            var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
            var objDataSvc = new BlogSvc();
            IEnumerable<Post> vAllPosts;
            if (vCurrUser.Role == Constants.Admin)
            {
                vAllPosts = objDataSvc.GetAllPosts(true, 0);
            }
            else { vAllPosts = objDataSvc.GetAllPosts(false, vCurrUser.UserID); }

            return View(vAllPosts);
        }


        public ActionResult EditPost(long aPostID)
        {
            var objDataSvc = new BlogSvc();
            Post vPost = objDataSvc.GetPostForEdit(aPostID);
            if (vPost == null)
            {
                return HttpNotFound();
            }
            vPost.UIPageTitle = "Edit Post";
            //Send you to NewPost.chtml to save copy same page 
            return View("NewPost", vPost);
        }
        public ActionResult NewPost()
        {
            Post newPost = new Post() {
                PostID =0,
                UIPageTitle = "New Post",
                CreatedOn =DateTime.Today};
            return View(newPost);
        }
        [HttpPost]
        public ActionResult NewPost(Post aNewPost)
        {
            var objDataSvc = new BlogSvc();
            var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
            aNewPost.UserID = vCurrUser.UserID;
            if (string.IsNullOrEmpty(aNewPost.FeaturedImage)) aNewPost.FeaturedImage = " ";
            bool bResult;
            if (aNewPost.PostID == 0)
            {
                bResult = objDataSvc.SaveNewBlog(aNewPost);
            }
            else {
                aNewPost.UpdatedOn = DateTime.Today;
                bResult = objDataSvc.UpdateBlog(aNewPost); }
            if (bResult) return RedirectToAction("ShowAllPosts", "BlogPosts");

            ModelState.AddModelError("", "Unable to Save Blog");
            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}