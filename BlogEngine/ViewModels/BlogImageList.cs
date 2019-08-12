using BlogEngine.Models;
using System.Collections.Generic;

namespace BlogEngine.ViewModels
{
    public class BlogImageList
    {
        public IEnumerable<BlogImage> BlogImages { get; set; }
        public Pager Pager { get; set; }
    }
}
