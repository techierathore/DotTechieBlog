using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TechieBlog.Models;

namespace TechieBlog.DataAccess
{
	 public class UserSettingDa : BaseDa
    {

		/// <summary>
		/// Saves a record to the UserSettings table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Insert(UserSetting aUserSetting)
		{
			bool blResult = false;
			if (ValidateValues(aUserSetting))
			{
				 throw new Exception("exists");
			}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@SettingsID",aUserSetting.SettingsID);
					 vParams.Add("@HomeImage",aUserSetting.HomeImage);
					 vParams.Add("@HomeImageText",aUserSetting.HomeImageText);
					 vParams.Add("@NumberOfLastPost",aUserSetting.NumberOfLastPost);
					 vParams.Add("@NumberOfCategory",aUserSetting.NumberOfCategory);
					 vParams.Add("@PostNumberInPage",aUserSetting.PostNumberInPage);
					 vParams.Add("@NumberOfTopPost",aUserSetting.NumberOfTopPost);
					 vParams.Add("@UpdatedTime",aUserSetting.UpdatedTime);
					 vParams.Add("@UserID",aUserSetting.UserID);
					 int iResult = vConn.Execute("UserSettingsInsert", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult == -1) blResult = true;
			 }
			 return blResult;
		}

		/// <summary>
		/// Updates record to the UserSettings table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Update(UserSetting aUserSetting)
		{
			bool blResult = false;
				if (ValidateValues(aUserSetting))
				{
					 throw new Exception("exists");
				}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@SettingsID",aUserSetting.SettingsID);
					 vParams.Add("@HomeImage",aUserSetting.HomeImage);
					 vParams.Add("@HomeImageText",aUserSetting.HomeImageText);
					 vParams.Add("@NumberOfLastPost",aUserSetting.NumberOfLastPost);
					 vParams.Add("@NumberOfCategory",aUserSetting.NumberOfCategory);
					 vParams.Add("@PostNumberInPage",aUserSetting.PostNumberInPage);
					 vParams.Add("@NumberOfTopPost",aUserSetting.NumberOfTopPost);
					 vParams.Add("@UpdatedTime",aUserSetting.UpdatedTime);
					 vParams.Add("@UserID",aUserSetting.UserID);
					 int iResult = vConn.Execute("UserSettingsUpdate", vParams, commandType: CommandType.StoredProcedure);
				 if (iResult == -1) blResult = true;
				 }
			return blResult;
		}

		/// <summary>
		/// Validate the values passed to save the details of UserSettings class, that wether those values are already present or not.
		/// </summary>
		 protected bool ValidateValues(UserSetting aUserSetting)
		{
			 bool blResult = true;
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@SettingsID",aUserSetting.SettingsID);
					 vParams.Add("@HomeImage",aUserSetting.HomeImage);
					 vParams.Add("@HomeImageText",aUserSetting.HomeImageText);
					 vParams.Add("@NumberOfLastPost",aUserSetting.NumberOfLastPost);
					 vParams.Add("@NumberOfCategory",aUserSetting.NumberOfCategory);
					 vParams.Add("@PostNumberInPage",aUserSetting.PostNumberInPage);
					 vParams.Add("@NumberOfTopPost",aUserSetting.NumberOfTopPost);
					 vParams.Add("@UpdatedTime",aUserSetting.UpdatedTime);
					 vParams.Add("@UserID",aUserSetting.UserID);
					 int iResult = vConn.Execute("UserSettingsValidate", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult >= 1) blResult = false;
			}
			return blResult;
		}
		/// <summary>
		/// Selects all records from the UserSettings table.
		/// </summary>
		 public IEnumerable<UserSetting> SelectAll()
		{
			 using (var vConn = OpenConnection())
			{
				 return vConn.Query<UserSetting>("UserSettingsSelectAll", commandType: CommandType.StoredProcedure).ToList();
			}
		}
		}
}
