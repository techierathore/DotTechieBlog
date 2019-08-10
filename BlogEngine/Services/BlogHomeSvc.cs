using BlogEngine.DataAccess;
using BlogEngine.Models;
using BlogEngine.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BlogEngine.Services
{
    public class BlogHomeSvc
    {
        public BlogHome LoadHomePage()
        {
            var vReturnObject = new BlogHome();
            vReturnObject.BlogPosts = GetAllBlogs(null);
            return vReturnObject;
        }

        public BlogList GetAllBlogs(int? iPageNo)
        {
            var objDataSvc = new PostDa();
            var vAllPosts = objDataSvc.GetPostsList();
            var vPager = new Pager(vAllPosts.Count, iPageNo);
            var vPagedList = new BlogList
            {
                BlogPosts = vAllPosts.Skip((vPager.CurrentPage - 1) * vPager.PageSize).Take(vPager.PageSize),
                Pager = vPager
            };
            return vPagedList;
        }
    }
}
