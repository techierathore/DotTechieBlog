using BlogEngine.Models;
using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class TagsController : Controller
    {
        public ActionResult ShowAllTags()
        {
            var objDataSvc = new BlogSvc();
            var vTags = objDataSvc.GetAllTags();
            return View(vTags);
        }
        public ActionResult EditTag(long aTagID)
        {
            var objDataSvc = new TagsNUserSvc();
            Tag vTag = objDataSvc.GetTagForEdit(aTagID);
            if (vTag == null)
            {
                return HttpNotFound();
            }
            vTag.UIPageTitle = "Edit Tag";
            //Send you to NewPost.chtml to save copy same page 
            return View("NewTag", vTag);
        }
        public ActionResult NewTag()
        {
            Tag newTag = new Tag() { TagID = 0, UIPageTitle = "New Tag" };
            return View(newTag);
        }
        [HttpPost]
        public ActionResult NewTag(Tag aNewTag)
        {
            var objDataSvc = new TagsNUserSvc();
            bool bResult;
            if (aNewTag.TagID == 0)
            {
                bResult = objDataSvc.SaveTag(aNewTag);
            }
            else { bResult = objDataSvc.UpdateTag(aNewTag); }
            if (bResult) return RedirectToAction("ShowAllTags", "Tags");

            ModelState.AddModelError("", "Unable to Save Tag");
            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}