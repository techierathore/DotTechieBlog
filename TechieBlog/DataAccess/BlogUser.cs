using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TechieBlog.Models;

namespace TechieBlog.DataAccess
{
	 public class BlogUserDa : BaseDa
    {


		/// <summary>
		/// Saves a record to the BlogUsers table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Insert(BlogUser aBlogUser)
		{
			bool blResult = false;
			if (ValidateValues(aBlogUser))
			{
				 throw new Exception("exists");
			}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@UserID",aBlogUser.UserID);
					 vParams.Add("@FirstName",aBlogUser.FirstName);
					 vParams.Add("@LastName",aBlogUser.LastName);
					 vParams.Add("@EmailID",aBlogUser.EmailID);
					 vParams.Add("@loginPassword",aBlogUser.LoginPassword);
					 vParams.Add("@Role",aBlogUser.Role);
					 vParams.Add("@CreatedTime",aBlogUser.CreatedTime);
					 vParams.Add("@UpdatedTime",aBlogUser.UpdatedTime);
					 vParams.Add("@LastLogin",aBlogUser.LastLogin);
					 int iResult = vConn.Execute("BlogUsersInsert", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult == -1) blResult = true;
			 }
			 return blResult;
		}

		/// <summary>
		/// Updates record to the BlogUsers table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Update(BlogUser aBlogUser)
		{
			bool blResult = false;
				if (ValidateValues(aBlogUser))
				{
					 throw new Exception("exists");
				}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@UserID",aBlogUser.UserID);
					 vParams.Add("@FirstName",aBlogUser.FirstName);
					 vParams.Add("@LastName",aBlogUser.LastName);
					 vParams.Add("@EmailID",aBlogUser.EmailID);
					 vParams.Add("@loginPassword",aBlogUser.LoginPassword);
					 vParams.Add("@Role",aBlogUser.Role);
					 vParams.Add("@CreatedTime",aBlogUser.CreatedTime);
					 vParams.Add("@UpdatedTime",aBlogUser.UpdatedTime);
					 vParams.Add("@LastLogin",aBlogUser.LastLogin);
					 int iResult = vConn.Execute("BlogUsersUpdate", vParams, commandType: CommandType.StoredProcedure);
				 if (iResult == -1) blResult = true;
				 }
			return blResult;
		}

		/// <summary>
		/// Validate the values passed to save the details of BlogUsers class, that wether those values are already present or not.
		/// </summary>
		 protected bool ValidateValues(BlogUser aBlogUser)
		{
			 bool blResult = true;
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@UserID",aBlogUser.UserID);
					 vParams.Add("@FirstName",aBlogUser.FirstName);
					 vParams.Add("@LastName",aBlogUser.LastName);
					 vParams.Add("@EmailID",aBlogUser.EmailID);
					 vParams.Add("@loginPassword",aBlogUser.LoginPassword);
					 vParams.Add("@Role",aBlogUser.Role);
					 vParams.Add("@CreatedTime",aBlogUser.CreatedTime);
					 vParams.Add("@UpdatedTime",aBlogUser.UpdatedTime);
					 vParams.Add("@LastLogin",aBlogUser.LastLogin);
					 int iResult = vConn.Execute("BlogUsersValidate", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult >= 1) blResult = false;
			}
			return blResult;
		}
		/// <summary>
		/// Selects all records from the BlogUsers table.
		/// </summary>
		 public IEnumerable<BlogUser> SelectAll()
		{
			 using (var vConn = OpenConnection())
			{
				 return vConn.Query<BlogUser>("BlogUsersSelectAll", commandType: CommandType.StoredProcedure).ToList();
			}
		}

		}
}
