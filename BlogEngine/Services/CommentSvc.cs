using BlogEngine.DataAccess;
using BlogEngine.Models;

namespace BlogEngine.Services
{
    public class CommentSvc
    {
        public bool SaveComment(BlogComment Comment)
        {
            var objDataAccess = new CommentDa();
            return objDataAccess.Insert(Comment);
        }
    }
}
