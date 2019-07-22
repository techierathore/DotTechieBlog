using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TechieBlog.Models;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult UploadImage()
        {
            return PartialView("UploadImage");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile()
        {
            string sImageName = string.Empty;

            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["MyImages"];
                if (pic.ContentLength > 0)
                {
                    var vFileName = Path.GetFileName(pic.FileName);
                    var vExtension = Path.GetExtension(pic.FileName);

                    sImageName = vFileName+ DateTime.Now.ToString("YYYYMMDDHHMMSS");

                    var vImageSavePath = Server.MapPath("/Upload/") + sImageName + vExtension;
                    sImageName = sImageName + vExtension;

                    ViewBag.Msg = vImageSavePath;
                    var path = vImageSavePath;

                    // Saving Image in Original Mode
                    pic.SaveAs(path);
                    var vImageLength = new FileInfo(path).Length;
                    var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
                    //here to add Image Path to You Database ,
                    BlogImage vBlogImage = new BlogImage
                    {
                        ImagePath = sImageName,
                        Size = Convert.ToInt32(vImageLength),
                        CreatedTime = DateTime.Now,
                        UserID= vCurrUser.UserID
                    };
                    //BlogImageDa vImageDa = new BlogImageDa();
                    //if (vImageDa.Insert(vBlogImage))
                    //{
                        TempData["message"] = string.Format("Image was Added Successfully");
                    //}
                }
            }
            return Json(Convert.ToString(sImageName), JsonRequestBehavior.AllowGet);
        }
    }
}