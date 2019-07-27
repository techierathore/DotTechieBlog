using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BlogEngine.Models;

namespace BlogEngine.DataAccess
{
	 public class BlogUserDa : BaseDa
    {

        public BlogUser GetLoginUser(string loginEmail, string loginPassword)
        {
            using (var vConn = OpenConnection())
            {
                var vReturnUser = vConn.Query<BlogUser>("GetLoginUser", new { LoginMail = loginEmail, LoginPassword = loginPassword }, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return vReturnUser;
            }
        }
        public BlogUser GetUserByEmail(string loginEmail)
        {
            using (var vConn = OpenConnection())
            {
                var vReturnUser = vConn.Query<BlogUser>("GetUserByEmail", new { LoginMail = loginEmail }, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return vReturnUser;
            }
        }
        /// <summary>
        /// Saves a record to the BlogUsers table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public bool Insert(BlogUser aBlogUser)
		{
			bool blResult = false;
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@FirstName",aBlogUser.FirstName);
					 vParams.Add("@LastName",aBlogUser.LastName);
					 vParams.Add("@EmailID",aBlogUser.EmailID);
					 vParams.Add("@loginPassword",aBlogUser.LoginPassword);
					 vParams.Add("@Role",aBlogUser.Role);
                vParams.Add("@CreatedTime", aBlogUser.CreatedTime);
                vParams.Add("@UpdatedTime", aBlogUser.UpdatedTime);
                int iResult = vConn.Execute("BlogUsersInsert", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult == 1) blResult = true;
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
