using BlogEngine.DataAccess;
using BlogEngine.Models;
using BlogEngine.ViewModels;

namespace BlogEngine.Services
{
    public class CommentSvc
    {
        public bool SaveComment(BlogComment Comment)
        {
            var objDataAccess = new CommentDa();
            return objDataAccess.Insert(Comment);
        }
        public BlogComment GetComment2Approve(long BlogCommentID)
        {
            var objDataAccess = new CommentDa();
            return objDataAccess.Select(BlogCommentID);
        }
        public bool ApproveComment(long BlogCommentID)
        {
            var objDataAccess = new CommentDa();
            return objDataAccess.ApproveBlogComment(BlogCommentID);
        }
        private const int _PageSize = Constants.ListPageSize;
        public CommentList GetAllComments(int? PageNo)
        {
            PageNo = PageNo != null ? PageNo : 1;
            var objDataSvc = new CommentDa();
            var vCount = objDataSvc.GetAdminCounts().CommentCount;
            var vPager = new Pager(vCount, PageNo, _PageSize);
            var vOffSet = (vPager.CurrentPage - 1) * vPager.PageSize;
            var vGetAllComments = objDataSvc.GetPagedComments(_PageSize, vOffSet);
            var vPagedList = new CommentList
            {
                BlogComments = vGetAllComments,
                Pager = vPager
            };
            return vPagedList;
        }
        public CommentList GetUnApprovedComments(int? PageNo)
        {
            PageNo = PageNo != null ? PageNo : 1;
            var objDataSvc = new CommentDa();
            var vCount = objDataSvc.GetAdminCounts().CommentCount;
            var vPager = new Pager(vCount, PageNo, _PageSize);
            var vOffSet = (vPager.CurrentPage - 1) * vPager.PageSize;
            var vGetAllComments = objDataSvc.GetPagedUnAppComments(_PageSize, vOffSet);
            var vPagedList = new CommentList
            {
                BlogComments = vGetAllComments,
                Pager = vPager
            };
            return vPagedList;
        }


    }
}
