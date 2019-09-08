using BlogEngine.DataAccess;
using BlogEngine.Models;
using BlogEngine.ViewModels;
using System.Collections.Generic;

namespace BlogEngine.Services
{
    public class BlogHomeSvc
    {
        private const int _PageSize = Constants.BlogListPageSize;
        public BlogList GetAllBlogs(int? PageNo)
        {
            var objDataSvc = new PostDa();
            var vPostForCounts = objDataSvc.GetTheCounts();
            if (vPostForCounts == null) return null;
            var vPostCount = vPostForCounts.BlogCount;
            var vPager = new Pager(vPostCount, PageNo, _PageSize);
            var vOffSet = (vPager.CurrentPage - 1) * vPager.PageSize;
            var vGetNextBlogs = objDataSvc.GetPostsList(_PageSize, vOffSet);
            var vPagedList = new BlogList
            {
                BlogPosts = vGetNextBlogs,
                Pager = vPager
            };
            return vPagedList;
        }
        public Post GetBlogForCounts()
        {
            var objDataSvc = new PostDa();
            var vPostCount = objDataSvc.GetTheCounts();
            return vPostCount;
        }
        public IEnumerable<Post> GetRecentBlogs()
        {
            var objDataSvc = new PostDa();
            var vRecentBlogs = objDataSvc.GetPostsList(3, 0);
            return vRecentBlogs;
        }
        public DisplayBlog GetDisplayBlog(long aPostID)
        {
            var objCommentDa = new CommentDa();
            var objDataAccess = new PostDa();
            var vSelPost = objDataAccess.Select(aPostID);
            if (vSelPost == null) return null;
            var vPostComments = objCommentDa.GetPostComments(vSelPost.PostID);
            BlogComment objNewComment = new BlogComment() { PostID= vSelPost.PostID }; 
            var objReturn = new DisplayBlog() {
                BlogPost = vSelPost,
                 BlogComments = vPostComments,
                NewComment = objNewComment
            };            
            return objReturn;
        }
        /// <summary>
        /// This Method is to show the Events of the User
        /// </summary>
        /// <param name="aBlogUserID"></param>
        /// <returns></returns>
        public IEnumerable<UserEvent> GetUserEvents(long aBlogUserID)
        {
            var objDataSvc = new UserEventDa();
            var vUserEvents = objDataSvc.GetUserEvents(aBlogUserID);
            return vUserEvents;
        }

    }
}
