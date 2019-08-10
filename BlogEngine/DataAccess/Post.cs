using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BlogEngine.Models;

namespace BlogEngine.DataAccess
{
    public class PostDa : BaseDa
    {

        /// <summary>
        /// Saves a record to the Posts table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public bool Insert(Post aPost)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@Title", aPost.Title);
                vParams.Add("@Abstract", aPost.Abstract);
                vParams.Add("@PostContent", aPost.PostContent);
                vParams.Add("@UserID", aPost.UserID);
                vParams.Add("@Tags", aPost.Tags);
                vParams.Add("@FeaturedImage", aPost.FeaturedImage);
                vParams.Add("@Published", aPost.Published);
                int iResult = vConn.Execute("PostInsert", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }

        /// <summary>
        /// Updates record to the Posts table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public bool Update(Post aPost)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogPostID", aPost.PostID);
                vParams.Add("@Title", aPost.Title);
                vParams.Add("@Abstract", aPost.Abstract);
                vParams.Add("@PostContent", aPost.PostContent);
                vParams.Add("@UserID", aPost.UserID);
                vParams.Add("@Tags", aPost.Tags);
                vParams.Add("@FeaturedImage", aPost.FeaturedImage);
                vParams.Add("@Published", aPost.Published);
                int iResult = vConn.Execute("PostUpdate", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }

        public Post Select(long PostID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogPostID", PostID);
                return vConn.Query<Post>("PostSelect", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        /// <summary>
        /// Selects all records from the Posts table based on given user ID.
        /// </summary>
        public IEnumerable<Post> AllPostsByUserID(long UserID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogUserID", UserID);
                return vConn.Query<Post>("PostsByUserID", vParams, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// Selects all records from the Posts table.
        /// </summary>
        public IEnumerable<Post> SelectAll()
        {
            using (var vConn = OpenConnection())
            {
                return vConn.Query<Post>("SelectAllPosts", commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<Post> GetPostsList()
        {
            using (var vConn = OpenConnection())
            {
                return vConn.Query<Post>("SelectAllPosts", commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}
