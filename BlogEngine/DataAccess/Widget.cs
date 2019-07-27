using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using BlogEngine.Models;

namespace BlogEngine.DataAccess
{
	 public class WidgetDa : BaseDa
    {

		/// <summary>
		/// Saves a record to the Widgets table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Insert(Widget aWidget)
		{
            bool blResult = false;
			if (ValidateValues(aWidget))
			{
				 throw new Exception("exists");
			}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@WidgetID",aWidget.WidgetID);
					 vParams.Add("@WidgetName",aWidget.WidgetName);
					 vParams.Add("@WidgetContent",aWidget.WidgetContent);
					 vParams.Add("@UpdatedTime",aWidget.UpdatedTime);
					 vParams.Add("@UserID",aWidget.UserID);
					 int iResult = vConn.Execute("WidgetsInsert", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult == -1) blResult = true;
			 }
			 return blResult;
		}

		/// <summary>
		/// Updates record to the Widgets table.
		/// returns True if value saved successfullyelse false
		/// Throw exception with message value 'EXISTS' if the data is duplicate
		/// </summary>
		public bool Update(Widget aWidget)
		{
			bool blResult = false;
				if (ValidateValues(aWidget))
				{
					 throw new Exception("exists");
				}
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@WidgetID",aWidget.WidgetID);
					 vParams.Add("@WidgetName",aWidget.WidgetName);
					 vParams.Add("@WidgetContent",aWidget.WidgetContent);
					 vParams.Add("@UpdatedTime",aWidget.UpdatedTime);
					 vParams.Add("@UserID",aWidget.UserID);
					 int iResult = vConn.Execute("WidgetsUpdate", vParams, commandType: CommandType.StoredProcedure);
				 if (iResult == -1) blResult = true;
				 }
			return blResult;
		}

		/// <summary>
		/// Validate the values passed to save the details of Widgets class, that wether those values are already present or not.
		/// </summary>
		 protected bool ValidateValues(Widget aWidget)
		{
			 bool blResult = true;
			 using (var vConn = OpenConnection())
				 {
				 var vParams = new DynamicParameters();
					 vParams.Add("@WidgetID",aWidget.WidgetID);
					 vParams.Add("@WidgetName",aWidget.WidgetName);
					 vParams.Add("@WidgetContent",aWidget.WidgetContent);
					 vParams.Add("@UpdatedTime",aWidget.UpdatedTime);
					 vParams.Add("@UserID",aWidget.UserID);
					 int iResult = vConn.Execute("WidgetsValidate", vParams, commandType: CommandType.StoredProcedure);
			 if (iResult >= 1) blResult = false;
			}
			return blResult;
		}
		/// <summary>
		/// Selects all records from the Widgets table.
		/// </summary>
		 public IEnumerable<Widget> SelectAll()
		{
			 using (var vConn = OpenConnection())
			{
				 return vConn.Query<Widget>("WidgetsSelectAll", commandType: CommandType.StoredProcedure).ToList();
			}
		}
		}
}
