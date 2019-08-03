using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BlogEngine.Models;

namespace BlogEngine.DataAccess
{
    public class BlogImageDa : BaseDa
    {
		/// <summary>
		/// Saves a record to the BlogImages table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Insert(BlogImage aBlogImage)
		{
			bool blResult = false;
            using (var vConn = OpenConnection())
            {
                var vParams = new DynamicParameters();
                vParams.Add("@ImageName", aBlogImage.ImageName);
                vParams.Add("@ImagePath", aBlogImage.ImagePath);
                vParams.Add("@Size", aBlogImage.Size);
                vParams.Add("@CreatedTime", aBlogImage.CreatedTime);
                vParams.Add("@UserID", aBlogImage.UserID);
                int iResult = vConn.Execute("BlogImageInsert", vParams, commandType: CommandType.StoredProcedure);
                if (iResult == 1) blResult = true;
            }
			 return blResult;
		}

		/// <summary>
		/// Updates record to the BlogImages table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Update(BlogImage aBlogImage)
		{
			bool blResult = false;
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@BlogImageID",aBlogImage.BlogImageID);
					 vParams.Add("@ImagePath",aBlogImage.ImagePath);
					 vParams.Add("@Size",aBlogImage.Size);
					 vParams.Add("@CreatedTime",aBlogImage.CreatedTime);
					 vParams.Add("@UserID",aBlogImage.UserID);
					 int iResult = vConn.Execute("BlogImagesUpdate", vParams, commandType: CommandType.StoredProcedure);
				 if (iResult == -1) blResult = true;
				 }
			return blResult;
		}

		/// <summary>
		/// Selects all records from the BlogImages table.
		/// </summary>
		 public IEnumerable<BlogImage> SelectAll()
		{
			 using (var vConn = OpenConnection())
			{
				 return vConn.Query<BlogImage>("BlogImagesSelectAll", commandType: CommandType.StoredProcedure).ToList();
			}
		}

		}
}
