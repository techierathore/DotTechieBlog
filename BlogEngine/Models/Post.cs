using System;

namespace BlogEngine.Models
{
    public class Post
	{
		/// <summary>
		/// Gets or sets the PostID value.
		/// </summary>
		public long PostID
		{ get; set; }

		/// <summary>
		/// Gets or sets the Title value.
		/// </summary>
		public string Title
		{ get; set; }

		/// <summary>
		/// Gets or sets the PostContent value.
		/// </summary>
		public string PostContent
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
		/// Gets or sets the UserID value.
		/// </summary>
		public long UserID
		{ get; set; }

		/// <summary>
		/// Gets or sets the Tags value.
		/// </summary>
		public string Tags
		{ get; set; }

		/// <summary>
		/// Gets or sets the CategoryId value.
		/// </summary>
		public int CategoryId
		{ get; set; }

		/// <summary>
		/// Gets or sets the Frequence value.
		/// </summary>
		public int Frequence
		{ get; set; }

		/// <summary>
		/// Gets or sets the FeaturedImage value.
		/// </summary>
		public string FeaturedImage
		{ get; set; }
        public bool Published
        { get; set; }        
    }
}
