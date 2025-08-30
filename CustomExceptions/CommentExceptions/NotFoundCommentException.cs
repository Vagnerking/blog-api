namespace blog_api.CustomExceptions.CommentExceptions
{
    public class NotFoundCommentException : Exception
    {
        public NotFoundCommentException() : base("Comentário não encontrado") { }
        public NotFoundCommentException(string message) : base(message) { }
    }
}
