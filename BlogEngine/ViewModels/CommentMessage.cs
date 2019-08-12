namespace BlogEngine.ViewModels
{
    public class CommentMessage
    {
        public string GivenBy  { get; set; }
        public string Message { get; set; }
        public string PostTitle { get; set; }
        public string PostImageUrl { get; set; }
        public long PostID { get; set; }
    }
}
