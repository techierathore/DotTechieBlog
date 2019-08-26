using BlogEngine.Models;
using BlogEngine.Services;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace TechieBlog.Controllers
{
    public class ImagesController : Controller
    {
        public ActionResult ImageList(int? PageNo)
        {
            var objDataSvc = new ImageSvc();
            var vAllPosts = objDataSvc.GetAllImages(PageNo);
            return View(vAllPosts);
        }

        public ActionResult UploadImage()
        {
            return PartialView("UploadImage");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult UploadFile(HttpPostedFileBase aUploadedFile)
        {
            var vReturnImagePath = string.Empty;
            if (aUploadedFile == null)
            {
                return Json(Convert.ToString(vReturnImagePath), JsonRequestBehavior.AllowGet);
            }
            if (aUploadedFile.ContentLength > 0)
            {
                var vFileName = Path.GetFileNameWithoutExtension(aUploadedFile.FileName);
                var vExtension = Path.GetExtension(aUploadedFile.FileName);

                string sImageName = vFileName + DateTime.Now.ToString("YYYYMMDDHHMMSS");

                var vImageSavePath = Server.MapPath("/BlogImages/") + sImageName + vExtension;
                //sImageName = sImageName + vExtension;
                vReturnImagePath = "/BlogImages/" + sImageName + vExtension;
                ViewBag.Msg = vImageSavePath;
                var path = vImageSavePath;

                // Saving Image in Original Mode
                aUploadedFile.SaveAs(path);
                var vImageLength = new FileInfo(path).Length;
                var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
                //here to add Image Path to You Database ,
                BlogImage vBlogImage = new BlogImage
                {
                    ImageName = Path.GetFileName(aUploadedFile.FileName),
                    ImagePath = sImageName,
                    Size = Convert.ToInt32(vImageLength),
                    CreatedTime = DateTime.Now,
                    UserID = vCurrUser.UserID
                };
                SaveImage(vBlogImage);
                TempData["message"] = string.Format("Image was Added Successfully");
            }
            return Json(Convert.ToString(vReturnImagePath), JsonRequestBehavior.AllowGet);
        }
        public bool SaveImage(BlogImage aBlogImage)
        {
            var objDataSvc = new ImageSvc();
            return objDataSvc.SaveImageToDb(aBlogImage);
        }
    }
}