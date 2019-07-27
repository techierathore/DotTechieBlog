using System;

namespace BlogEngine.Models
{
    public class BlogUser
	{

		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public long UserID
		{ get; set; }

		/// <summary>
		/// Gets or sets the FirstName value.
		/// </summary>
		public string FirstName
		{ get; set; }

		/// <summary>
		/// Gets or sets the LastName value.
		/// </summary>
		public string LastName
		{ get; set; }

		/// <summary>
		/// Gets or sets the EmailID value.
		/// </summary>
		public string EmailID
		{ get; set; }

		/// <summary>
		/// Gets or sets the LoginPassword value.
		/// </summary>
		public string LoginPassword
		{ get; set; }

		/// <summary>
		/// Gets or sets the Role value.
		/// </summary>
		public string Role
		{ get; set; }

		/// <summary>
		/// Gets or sets the CreatedTime value.
		/// </summary>
		public DateTime CreatedTime
		{ get; set; }

		/// <summary>
		/// Gets or sets the UpdatedTime value.
		/// </summary>
		public DateTime UpdatedTime
		{ get; set; }

		/// <summary>
		/// Gets or sets the LastLogin value.
		/// </summary>
		public DateTime LastLogin
		{ get; set; }


	}
}
