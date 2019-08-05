using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class TagsNUsersController : Controller
    {     
        public ActionResult ShowAllTags()
        {
            var objDataSvc = new BlogSvc();
            var vTags = objDataSvc.GetAllTags();
            return View(vTags);
        }

        public ActionResult EditTag(long aTagID)
        {
            //var objDataSvc = new BlogSvc();
            //Post vPost = objDataSvc.GetPostForEdit(aPostID);
            //if (vPost == null)
            //{
            //    return HttpNotFound();
            //}
            ////Send you to NewPost.chtml to save copy same page 
            //return View("NewPost", vPost);
            return View();
        }
    }
}