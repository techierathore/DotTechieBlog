using BlogEngine.Models;
using System.Collections.Generic;

namespace BlogEngine.ViewModels
{
    public class DisplayBlog
    {
        public Post BlogPost { get; set; }
        public BlogComment NewComment { get; set; }
        public IEnumerable<BlogComment> BlogComments { get; set; }
        public Post NextPost { get; set; }
        public Post PrevPost { get; set; }
    }
}
