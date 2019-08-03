using BlogEngine.DataAccess;
using BlogEngine.Models;
using System.Collections.Generic;

namespace BlogEngine.Services
{
    public class BlogSvc
    {
        public IEnumerable<Tag> GetAllTags()
        {
            var objDataAccess = new TagDa();
            return objDataAccess.SelectAll();
        }

        public bool SaveNewBlog(Post aNewBlog)
        {
            var objDataAccess = new PostDa();
            return objDataAccess.Insert(aNewBlog);       
        }

        public bool UpdateBlog(Post aNewBlog)
        {
            var objDataAccess = new PostDa();
            return objDataAccess.Update(aNewBlog);
        }
    }
}
