using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        public ActionResult AllCommentsList(int? PageNo)
        {
            var objDataSvc = new CommentSvc();
            var vAllPosts = objDataSvc.GetAllComments(PageNo);
            return View(vAllPosts);
        }
        public ActionResult UnApprovedList(int? PageNo)
        {
            var objDataSvc = new CommentSvc();
            var vAllPosts = objDataSvc.GetUnApprovedComments(PageNo);
            return View(vAllPosts);
        }
        public ActionResult ApproveComment(long BlogCommentID)
        {
            var objDataSvc = new CommentSvc();
            if (objDataSvc.ApproveComment(BlogCommentID))
            {               
                var vAllPosts = objDataSvc.GetAllComments(1);
                return View("AllCommentsList", vAllPosts);
            }
            //Send you to NewPost.chtml to save copy same page 
            return View("UnApprovedList");
        }
    }
}