using System;
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
            if (ValidateValues(aTag))
            {
                throw new Exception("exists");
            }
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@TagID", aTag.TagID);
                vParams.Add("@TagName", aTag.TagName);
                int iResult = vConn.Execute("TagsInsert", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == -1) blResult = true;
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
            if (ValidateValues(aTag))
            {
                throw new Exception("exists");
            }
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@TagID", aTag.TagID);
                vParams.Add("@TagName", aTag.TagName);
                int iResult = vConn.Execute("TagsUpdate", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == -1) blResult = true;
            }
            return blResult;
        }

        /// <summary>
        /// Validate the values passed to save the details of Tags class, that wether those values are already present or not.
        /// </summary>
        protected bool ValidateValues(Tag aTag)
        {
            bool blResult = true;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@TagID", aTag.TagID);
                vParams.Add("@TagName", aTag.TagName);
                int iResult = vConn.Execute("TagsValidate", vParams, commandType: CommandType.StoredProcedure);
                if (iResult >= 1) blResult = false;
            }
            return blResult;
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
