using System;

namespace BlogEngine.Models
{
    public class BlogComment
	{

		/// <summary>
		/// Gets or sets the CommentID value.
		/// </summary>
		public long CommentID
		{ get; set; }

		/// <summary>
		/// Gets or sets the PostID value.
		/// </summary>
		public long PostID
		{ get; set; }

		/// <summary>
		/// Gets or sets the ComntDateTime value.
		/// </summary>
		public DateTime ComntDateTime
		{ get; set; }

		/// <summary>
		/// Gets or sets the Name value.
		/// </summary>
		public string Name
		{ get; set; }

		/// <summary>
		/// Gets or sets the Email value.
		/// </summary>
		public string Email
		{ get; set; }

		/// <summary>
		/// Gets or sets the Comment value.
		/// </summary>
		public string Comment
		{ get; set; }

		/// <summary>
		/// Gets or sets the Publish value.
		/// </summary>
		public bool Publish
		{ get; set; }

        public string CommenterSite
        { get; set; }
    }
}
