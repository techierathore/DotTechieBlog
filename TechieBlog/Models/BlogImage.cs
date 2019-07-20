using System;

namespace TechieBlog.Models
{
    public class BlogImage
	{

		/// <summary>
		/// Gets or sets the BlogImageID value.
		/// </summary>
		public long BlogImageID
		{ get; set; }

		/// <summary>
		/// Gets or sets the ImagePath value.
		/// </summary>
		public string ImagePath
		{ get; set; }

		/// <summary>
		/// Gets or sets the Size value.
		/// </summary>
		public int Size
		{ get; set; }

		/// <summary>
		/// Gets or sets the CreatedTime value.
		/// </summary>
		public DateTime CreatedTime
		{ get; set; }

		/// <summary>
		/// Gets or sets the UserID value.
		/// </summary>
		public long UserID
		{ get; set; }


	}
}
