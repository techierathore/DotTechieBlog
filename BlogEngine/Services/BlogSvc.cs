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

        public IEnumerable<Post> GetAllPosts(bool aIsAdmin,long aUserID)
        {
            var objDataAccess = new PostDa();
            if (aIsAdmin)
            {
                return objDataAccess.SelectAll();
            }
            else return objDataAccess.AllPostsByUserID(aUserID);
        }
        public Post GetPostForEdit(long aPostID)
        {
            var objDataAccess = new PostDa();
            return objDataAccess.Select(aPostID);
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
