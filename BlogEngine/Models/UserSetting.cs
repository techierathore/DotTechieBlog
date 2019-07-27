using System;

namespace BlogEngine.Models
{
    public class UserSetting
	{
		/// <summary>
		/// Gets or sets the SettingsID value.
		/// </summary>
		public long SettingsID
		{ get; set; }

		/// <summary>
		/// Gets or sets the HomeImage value.
		/// </summary>
		public string HomeImage
		{ get; set; }

		/// <summary>
		/// Gets or sets the HomeImageText value.
		/// </summary>
		public string HomeImageText
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumberOfLastPost value.
		/// </summary>
		public byte NumberOfLastPost
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumberOfCategory value.
		/// </summary>
		public byte NumberOfCategory
		{ get; set; }

		/// <summary>
		/// Gets or sets the PostNumberInPage value.
		/// </summary>
		public byte PostNumberInPage
		{ get; set; }

		/// <summary>
		/// Gets or sets the NumberOfTopPost value.
		/// </summary>
		public byte NumberOfTopPost
		{ get; set; }

		/// <summary>
		/// Gets or sets the UpdatedTime value.
		/// </summary>
		public DateTime UpdatedTime
		{ get; set; }

		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public long UserID
		{ get; set; }

	}
}
