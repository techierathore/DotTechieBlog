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
    }
}
