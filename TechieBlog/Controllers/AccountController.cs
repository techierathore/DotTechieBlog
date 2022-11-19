using BlogEngine.Models;
using BlogEngine.Services;
using System;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(BlogUser aLoginUser, string aReturnUrl)
        {
            if (!ModelState.IsValid) return View(aLoginUser);
            var objDataSvc = new AccountSvc();
            var selUser = objDataSvc.BlogLogin(aLoginUser);
            if (selUser != null)
            {
                Session[Constants.LoggedUser] = selUser;
                if (!string.IsNullOrEmpty(aReturnUrl))
                {
                    return Redirect(aReturnUrl);
                }
                else if (selUser.Role == Constants.Admin || selUser.Role == Constants.BlogUser)
                {
                    return RedirectToAction("AdminHome", "AdminDashboard");
                }
                else return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            // If we got this far, something failed, redisplay form
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(BlogUser aNewUser)
        {
            if (!ModelState.IsValid) return View(aNewUser);
            try
            {
                var objAccSvc = new AccountSvc();
                aNewUser.Role = Constants.BlogUser;
                var vNewUser = objAccSvc.BlogSignUp(aNewUser);
                if (vNewUser != null)
                {
                    Session[Constants.LoggedUser] = vNewUser;
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Error " + ex.Message;
            }
            // If we got this far, something failed, redisplay form
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}