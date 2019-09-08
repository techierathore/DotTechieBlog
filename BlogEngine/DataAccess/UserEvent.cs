using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BlogEngine.Models;

namespace BlogEngine.DataAccess
{
    /// <summary>
    /// TODO Rename the file 
    /// </summary>
    public class UserEventDa : BaseDa
    {

        /// <summary>
        /// Saves a record to the UserEvent table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public bool Insert(UserEvent aUserSetting)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@pLogoIconPath", aUserSetting.LogoIconPath);
                vParams.Add("@pEventTitle", aUserSetting.EventTitle);
                vParams.Add("@pSessionTitle", aUserSetting.SessionTitle);
                vParams.Add("@pEventUrl", aUserSetting.EventUrl);
                vParams.Add("@pEventDate", aUserSetting.EventDate);
                vParams.Add("@pType", aUserSetting.Type);
                vParams.Add("@BlogUserID", aUserSetting.UserID);
                int iResult = vConn.Execute("UserEventInsert ", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }
        public bool Update(UserEvent aUserSetting)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@UserEventID", aUserSetting.EventID);
                vParams.Add("@pLogoIconPath", aUserSetting.LogoIconPath);
                vParams.Add("@pEventTitle", aUserSetting.EventTitle);
                vParams.Add("@pSessionTitle", aUserSetting.SessionTitle);
                vParams.Add("@pEventUrl", aUserSetting.EventUrl);
                vParams.Add("@pEventDate", aUserSetting.EventDate);
                vParams.Add("@pType", aUserSetting.Type);
                vParams.Add("@pUserID", aUserSetting.UserID);
                int iResult = vConn.Execute("UserEventUpdate", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }
        public UserEvent Select(long EventID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@UserEventID", EventID);
                return vConn.Query<UserEvent>("UserEventSelect", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        /// <summary>
        /// Selects all records from the UserEvents table.
        /// </summary>
        public IEnumerable<UserEvent> GetUserEvents(long UserID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@BlogUserID", UserID);
                return vConn.Query<UserEvent>("GetUserEvents", vParams, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
