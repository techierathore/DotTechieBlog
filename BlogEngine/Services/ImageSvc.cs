using BlogEngine.DataAccess;
using BlogEngine.Models;

namespace BlogEngine.Services
{
    public class ImageSvc
    {
        public bool SaveImageToDb(BlogImage aNewImage)
        {
            var objDataAccess = new BlogImageDa();
            return objDataAccess.Insert(aNewImage);
        }
    }
}
