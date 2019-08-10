using BlogEngine.Models;
using System.Collections.Generic;

namespace BlogEngine.ViewModels
{
    public class BlogList
    {
        public IEnumerable<Post> BlogPosts { get; set; }
        public Pager Pager { get; set; }
    }
}
