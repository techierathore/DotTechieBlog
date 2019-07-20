using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TechieBlog.Models;

namespace TechieBlog.DataAccess
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
			if (ValidateValues(aBlogImage))
			{
				 throw new Exception("exists");
			}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@BlogImageID",aBlogImage.BlogImageID);
					 vParams.Add("@ImagePath",aBlogImage.ImagePath);
					 vParams.Add("@Size",aBlogImage.Size);
					 vParams.Add("@CreatedTime",aBlogImage.CreatedTime);
					 vParams.Add("@UserID",aBlogImage.UserID);
					 int iResult = vConn.Execute("BlogImagesInsert", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult == -1) blResult = true;
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
				if (ValidateValues(aBlogImage))
				{
					 throw new Exception("exists");
				}
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
		/// Validate the values passed to save the details of BlogImages class, that wether those values are already present or not.
		/// </summary>
		 protected bool ValidateValues(BlogImage aBlogImage)
		{
			 bool blResult = true;
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@BlogImageID",aBlogImage.BlogImageID);
					 vParams.Add("@ImagePath",aBlogImage.ImagePath);
					 vParams.Add("@Size",aBlogImage.Size);
					 vParams.Add("@CreatedTime",aBlogImage.CreatedTime);
					 vParams.Add("@UserID",aBlogImage.UserID);
					 int iResult = vConn.Execute("BlogImagesValidate", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult >= 1) blResult = false;
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
