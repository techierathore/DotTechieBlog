using BlogEngine.DataAccess;
using BlogEngine.Models;
using BlogEngine.ViewModels;
using System;

namespace BlogEngine.Services
{
    public class CommentSvc
    {
        private const int _PageSize = Constants.ListPageSize;
        public bool SaveComment(BlogComment Comment)
        {
            var objDataAccess = new CommentDa();
            Comment.GivenOn = DateTime.Today;
            return objDataAccess.Insert(Comment);
        }
        public BlogComment GetComment(long BlogCommentID)
        {
            var objDataAccess = new CommentDa();
            return objDataAccess.Select(BlogCommentID);
        }
        public bool ApproveComment(long BlogCommentID)
        {
            var objDataAccess = new CommentDa();
            return objDataAccess.ApproveBlogComment(BlogCommentID);
        }
     
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
