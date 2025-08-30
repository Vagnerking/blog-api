namespace blog_api.CustomExceptions.PostExceptions
{
    public class NotFoundPostException : Exception
    {
        public NotFoundPostException() : base("Post não encontrado") { }
        public NotFoundPostException(string message) : base(message) { }
    }
}
