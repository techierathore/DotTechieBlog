using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BlogEngine.Models;

namespace BlogEngine.DataAccess
{
    public class TagDa : BaseDa
    {

        /// <summary>
        /// Saves a record to the Tags table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public bool Insert(Tag aTag)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@pTagName", aTag.TagName);
                int iResult = vConn.Execute("TagInsert", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }

        /// <summary>
        /// Updates record to the Tags table.
        /// returns True if value saved successfullyelse false
        /// Throw exception with message value 'EXISTS' if the data is duplicate
        /// </summary>
        public bool Update(Tag aTag)
        {
            bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@pTagID", aTag.TagID);
                vParams.Add("@pTagName", aTag.TagName);
                int iResult = vConn.Execute("TagUpdate", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
            return blResult;
        }

        public Tag Select(long TagID)
        {
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@pTagID", TagID);
                return vConn.Query<Tag>("TagSelect", vParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
        /// <summary>
        /// Selects all records from the Tags table.
        /// </summary>
        public IEnumerable<Tag> SelectAll()
        {
            using (var vConn = OpenConnection())
            {
                return vConn.Query<Tag>("GetAllTags", commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
