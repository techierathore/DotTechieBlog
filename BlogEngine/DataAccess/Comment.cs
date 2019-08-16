using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BlogEngine.Models;

namespace BlogEngine.DataAccess
{
    public class CommentDa : BaseDa
    {
        /// <summary>
        /// Saves a record to the Comments table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public bool Insert(BlogComment aComment)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@pPostID", aComment.PostID);
                vParams.Add("@pGivenOn", aComment.GivenOn);
                vParams.Add("@pGivenBy", aComment.GivenBy);
                vParams.Add("@pEmail", aComment.Email);
                vParams.Add("@pComment", aComment.Comment);
                vParams.Add("@pPublish", aComment.Published);
                vParams.Add("@pParentID", aComment.ParentCommentID);
                int iResult = vConn.Execute("BlogCommentInsert", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }

        public bool ApproveBlogComment(long BlogCommentID)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogCommentID", BlogCommentID);
                int iResult = vConn.Execute("ApproveBlogComment", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }
        public BlogComment Select(long BlogCommentID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogCommentID", BlogCommentID);
                return vConn.Query<BlogComment>("BlogCommentSelect", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IEnumerable<BlogComment> GetPagedUnAppComments(int PageSize, int OffSet)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@aPageSize", PageSize);
                vParams.Add("@aOffset", OffSet);
                return vConn.Query<BlogComment>("GetPagedUnAppComments", vParams, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public IEnumerable<BlogComment> GetPagedComments(int PageSize, int OffSet)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@aPageSize", PageSize);
                vParams.Add("@aOffset", OffSet);
                return vConn.Query<BlogComment>("GetPagedComments", vParams, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<BlogComment> GetPostComments(long BlogPostID)
        {
            IEnumerable<BlogComment> vRetObject = GetPostParentComments(BlogPostID);
            IEnumerable<BlogComment> vChildObject = GetPostChildComments(BlogPostID);
            if (vRetObject == null) return null;
            List<BlogComment> vRetChildObject = new List<BlogComment>();
            foreach (var vItem in vRetObject)
            {
                var vReplies = (from c in vChildObject
                                 where c.ParentCommentID == vItem.CommentID
                                 select c).ToList();
                vItem.Replies = vReplies;
            }
            return vRetObject;
        }
        public IEnumerable<BlogComment> GetPostParentComments(long BlogPostID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogPostID", BlogPostID);
                return vConn.Query<BlogComment>("GetPostParentComments", vParams, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public IEnumerable<BlogComment> GetPostChildComments(long BlogPostID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogPostID", BlogPostID);
                return vConn.Query<BlogComment>("GetPostChildComments", vParams, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public AdminCounts GetAdminCounts()
        {
            using (var vConn = OpenConnection())
            {
                return vConn.Query<AdminCounts>("GetAdminCounts", commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
