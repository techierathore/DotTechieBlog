using BlogEngine.DataAccess;
using BlogEngine.Models;
using BlogEngine.ViewModels;

namespace BlogEngine.Services
{
    public class ImageSvc
    {
        private const int _PageSize = Constants.ListPageSize;
        public BlogImageList GetAllImages(int? PageNo)
        {
            PageNo = PageNo != null ? PageNo : 1;

            var objDataSvc = new BlogImageDa();
            var vCount = new CommentDa().GetAdminCounts().ImageCount;
            var vPager = new Pager(vCount, PageNo, _PageSize);
            var vOffSet = (vPager.CurrentPage - 1) * vPager.PageSize;
            var vGetAllImages = objDataSvc.GetPagedImages(_PageSize, vOffSet);
            var vPagedList = new BlogImageList
            {
                BlogImages = vGetAllImages,
                Pager = vPager
            };
            return vPagedList;
        }
        public bool SaveImageToDb(BlogImage aNewImage)
        {
            var objDataAccess = new BlogImageDa();
            return objDataAccess.Insert(aNewImage);
        }
    }
}
