using System;
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
					 vParams.Add("@PostID",aPost.PostID);
					 vParams.Add("@Title",aPost.Title);
					 vParams.Add("@PostContent",aPost.PostContent);
					 vParams.Add("@CreatedTime",aPost.CreatedTime);
					 vParams.Add("@UpdatedTime",aPost.UpdatedTime);
					 vParams.Add("@UserID",aPost.UserID);
					 vParams.Add("@Tags",aPost.Tags);
					 vParams.Add("@CategoryId",aPost.CategoryId);
					 vParams.Add("@Frequence",aPost.Frequence);
					 vParams.Add("@FeaturedImage",aPost.FeaturedImage);
					 int iResult = vConn.Execute("PostsUpdate", vParams, commandType: CommandType.StoredProcedure);
				 if (iResult == -1) blResult = true;
				 }
			return blResult;
		}

		/// <summary>
		/// Selects all records from the Posts table.
		/// </summary>
		 public IEnumerable<Post> SelectAll()
		{
			 using (var vConn = OpenConnection())
			{
				 return vConn.Query<Post>("PostsSelectAll", commandType: CommandType.StoredProcedure).ToList();
			}
		}

		}
}
