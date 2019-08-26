using BlogEngine.Models;
using BlogEngine.Services;
using System.Web.Mvc;

namespace TechieBlog.Controllers
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

        public ActionResult ReplyComment(long BlogCommentID)
        {
            var objDataSvc = new CommentSvc();
            var vSelComment = objDataSvc.GetComment(BlogCommentID);
            return View(vSelComment);
        }
        [HttpPost]
        public ActionResult ReplyComment(BlogComment ReplyComment)
        {
            var vCurrUser = (BlogUser)Session[Constants.LoggedUser];
            var objDataSvc = new CommentSvc();
            var vReply = new BlogComment()
            {
                PostID = ReplyComment.PostID,
                ParentCommentID = ReplyComment.CommentID,
                Comment = ReplyComment.Comment,
                Published = true,
                GivenBy = vCurrUser.FirstName,
                Email = vCurrUser.EmailID
            };
            if (objDataSvc.SaveComment(vReply))
            {
                var vAllPosts = objDataSvc.GetAllComments(1);
                return View("AllCommentsList", vAllPosts);
            }
            return View();
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