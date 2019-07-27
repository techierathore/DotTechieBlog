using BlogEngine.DataAccess;
using BlogEngine.Models;
using System;

namespace BlogEngine.Services
{
    public class AccountSvc
    {
        public BlogUser BlogLogin(BlogUser aLoginUser) {
            var objDataAccess = new BlogUserDa();
            BlogUser vLoggerUser = objDataAccess.GetLoginUser(aLoginUser.EmailID, aLoginUser.LoginPassword);
            return vLoggerUser;
        }

        public BlogUser BlogSignUp(BlogUser aNewUser)
        {
            BlogUser vNewUser = null;
            var objDataAccess = new BlogUserDa();
            var vCheckUserByEmail = objDataAccess.GetUserByEmail(aNewUser.EmailID);
            if (vCheckUserByEmail != null) throw new Exception("User with this Email already present use login or Forgot Password (if you had forgotten the password) ");
            if (objDataAccess.Insert(aNewUser))
            {
                vNewUser = objDataAccess.GetUserByEmail(aNewUser.EmailID);
            }
            return vNewUser;
        }

    }
}
