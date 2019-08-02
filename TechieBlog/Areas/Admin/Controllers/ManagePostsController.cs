using BlogEngine.Models;
using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class ManagePostsController : Controller
    {
        // GET: Admin/ManagePosts
        public ActionResult ShowAllPosts()
        {
            return View();
        }
        public ActionResult NewPost()
        {
            Post newPost = new Post() { PostID = 0 };
            return View(newPost);
        }
        [HttpPost]
        public ActionResult NewPost(Post aNewPost)
        {
            return View();
        }
    }
}