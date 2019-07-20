using CaptchaMvc.HtmlHelpers;
using System;
using System.Web.Mvc;
using TechieBlog.DataAccess;
using TechieBlog.Models;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(BlogUser loginUser, string returnUrl)
        {
            if (!this.IsCaptchaValid("Captcha is not valid"))
            {
                ViewBag.errormessage = "Error: captcha entered is not valid.";
                return View(loginUser);
            }
            if (!ModelState.IsValid) return View(loginUser);
            var objDataAccess = new BlogUserDa();
            var selUser = objDataAccess.GetLoginUser(loginUser.EmailID, loginUser.LoginPassword);
            if (selUser != null)
            {
                Session[Constants.LoggedUser] = selUser;
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else if (selUser.Role == Constants.Admin || selUser.Role == Constants.BlogUser)
                {
                    return RedirectToAction("Index", "Dashboard", new { Area = "Admin" });
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
            if (!this.IsCaptchaValid("Captcha is not valid"))
            {
                ViewBag.errormessage = "Error: captcha entered is not valid.";
                return View(aNewUser);
            }
            if (!ModelState.IsValid) return View(aNewUser);
            try
            {
                var objDataAccess = new BlogUserDa();
                var vCheckUserByEmail = objDataAccess.GetUserByEmail(aNewUser.EmailID);
                if (vCheckUserByEmail != null) throw new Exception("User with this Email already present use login or Forgot Password (if you had forgotten the password) ");
                aNewUser.Role = Constants.BlogUser;

                if (objDataAccess.Insert(aNewUser))
                {
                    var vAddedUser = objDataAccess.GetUserByEmail(aNewUser.EmailID);
                    Session[Constants.LoggedUser] = vAddedUser;
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