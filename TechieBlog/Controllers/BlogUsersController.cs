using BlogEngine.Models;
using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class BlogUsersController : Controller
    {
        public ActionResult UsersList()
        {
            return View();
        }
        public ActionResult UserProfile()
        {
            BlogUser vCurrUser = (BlogUser)Session[Constants.LoggedUser];
            var objDataSvc = new BlogHomeSvc();
            var vUserEvents = objDataSvc.GetUserEvents(vCurrUser.UserID);
            return View(vUserEvents);
        }
        public ActionResult EditEvent(long aEventID)
        {
            var objDataSvc = new TagsNUserSvc();
            UserEvent vUserEvent = objDataSvc.GetEventForEdit(aEventID);
            if (vUserEvent == null)
            {
                return HttpNotFound();
            }
            vUserEvent.UIPageTitle = "Edit Event";
            //Send you to NewPost.chtml to save copy same page 
            return View("AddEvent", vUserEvent);
        }
        public ActionResult AddEvent()
        {
            UserEvent vNewEvent = new UserEvent() { EventID = 0, UIPageTitle = "New Event" };
            return View(vNewEvent);
        }
        [HttpPost]
        public ActionResult AddEvent(UserEvent aNewEvent)
        {
            var objDataSvc = new TagsNUserSvc();
            var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
            aNewEvent.UserID = vCurrUser.UserID;
            if (string.IsNullOrEmpty(aNewEvent.LogoIconPath)) aNewEvent.LogoIconPath = " ";
            bool bResult;
            if (aNewEvent.EventID == 0)
            {
                bResult = objDataSvc.SaveNewEvent(aNewEvent);
            }
            else { bResult = objDataSvc.UpdateEvent(aNewEvent); }
            if (bResult) return RedirectToAction("UserProfile", "BlogUsers");

            ModelState.AddModelError("", "Unable to Save Blog");
            // If we got this far, something failed, redisplay form
            return View();
        }
    }
}