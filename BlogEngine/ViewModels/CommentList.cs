using BlogEngine.Models;
using System.Collections.Generic;

namespace BlogEngine.ViewModels
{
    public class CommentList
    {
        public IEnumerable<BlogComment> BlogComments { get; set; }
        public Pager Pager { get; set; }
    }
}
