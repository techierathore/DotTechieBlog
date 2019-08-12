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
                int iResult = vConn.Execute("BlogCommentInsert", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }


        /// <summary>
        /// Selects all records from the Comments table.
        /// </summary>
        public IEnumerable<BlogComment> SelectAll()
        {
            using (var vConn = OpenConnection())
            {
                return vConn.Query<BlogComment>("CommentsSelectAll", commandType: CommandType.StoredProcedure).ToList();
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
