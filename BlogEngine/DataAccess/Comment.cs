using System;
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
			if (ValidateValues(aComment))
			{
				 throw new Exception("exists");
			}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@CommentID",aComment.CommentID);
					 vParams.Add("@PostID",aComment.PostID);
					 vParams.Add("@ComntDateTime",aComment.ComntDateTime);
					 vParams.Add("@Name",aComment.Name);
					 vParams.Add("@Email",aComment.Email);
					 vParams.Add("@Comment",aComment.Comment);
					 vParams.Add("@Publish",aComment.Publish);
					 int iResult = vConn.Execute("CommentsInsert", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult == -1) blResult = true;
			 }
			 return blResult;
		}

		/// <summary>
		/// Updates record to the Comments table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Update(BlogComment aComment)
		{
			bool blResult = false;
				if (ValidateValues(aComment))
				{
					 throw new Exception("exists");
				}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@CommentID",aComment.CommentID);
					 vParams.Add("@PostID",aComment.PostID);
					 vParams.Add("@ComntDateTime",aComment.ComntDateTime);
					 vParams.Add("@Name",aComment.Name);
					 vParams.Add("@Email",aComment.Email);
					 vParams.Add("@Comment",aComment.Comment);
					 vParams.Add("@Publish",aComment.Publish);
					 int iResult = vConn.Execute("CommentsUpdate", vParams, commandType: CommandType.StoredProcedure);
				 if (iResult == -1) blResult = true;
				 }
			return blResult;
		}

		/// <summary>
		/// Validate the values passed to save the details of Comments class, that wether those values are already present or not.
		/// </summary>
		 protected bool ValidateValues(BlogComment aComment)
		{
			 bool blResult = true;
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@CommentID",aComment.CommentID);
					 vParams.Add("@PostID",aComment.PostID);
					 vParams.Add("@ComntDateTime",aComment.ComntDateTime);
					 vParams.Add("@Name",aComment.Name);
					 vParams.Add("@Email",aComment.Email);
					 vParams.Add("@Comment",aComment.Comment);
					 vParams.Add("@Publish",aComment.Publish);
					 int iResult = vConn.Execute("CommentsValidate", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult >= 1) blResult = false;
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

		}
}
