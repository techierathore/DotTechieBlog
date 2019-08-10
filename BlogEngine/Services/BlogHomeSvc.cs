using BlogEngine.DataAccess;
using BlogEngine.Models;
using BlogEngine.ViewModels;
using System.Collections.Generic;

namespace BlogEngine.Services
{
    public class BlogHomeSvc
    {
        private const int _PageSize = 5;
        public BlogList Index()
        {
            var objDataSvc = new PostDa();
            var vGetForHome = objDataSvc.GetPostsList(_PageSize, 0);
            var vPostCount = objDataSvc.GetTheCounts().BlogCount;
            var vPager = new Pager(vPostCount, 1, _PageSize);
            var vPagedList = new BlogList
            {
                BlogPosts = vGetForHome,
                Pager = vPager
            };
            return vPagedList;
        }
        public BlogList GetAllBlogs(int? PageNo)
        {
            var objDataSvc = new PostDa();
            var vPostCount = objDataSvc.GetTheCounts().BlogCount;
            var vPager = new Pager(vPostCount, PageNo, _PageSize);
            var vOffSet = (vPager.CurrentPage - 1) * vPager.PageSize;
            var vGetNextBlogs = objDataSvc.GetPostsList(_PageSize, vOffSet);
            var vPagedList = new BlogList
            {
                BlogPosts = vGetNextBlogs,
                Pager = vPager
            };
            return vPagedList;
        }
        public Post GetBlogForCounts()
        {
            var objDataSvc = new PostDa();
            var vPostCount = objDataSvc.GetTheCounts();
            return vPostCount;
        }
        public IEnumerable<Post> GetRecentBlogs()
        {
            var objDataSvc = new PostDa();
            var vRecentBlogs = objDataSvc.GetPostsList(3, 0);
            return vRecentBlogs;
        }
    }
}
