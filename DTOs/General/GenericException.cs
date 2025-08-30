namespace blog_api.DTOs.General
{
    public class GenericExceptionDto
    {
        public string LegibleMessage { get; set; } = string.Empty;

        public string SystemMessage { get; set; } = string.Empty;

        public int StatusCode { get; set; }


        public GenericExceptionDto(string legibleMessage, string systemMessage, int statusCode)
        {
            LegibleMessage = legibleMessage;
            SystemMessage = systemMessage;
            StatusCode = statusCode;
        }

        public GenericExceptionDto(string legibleMessage, int statusCode)
        {
            LegibleMessage = legibleMessage;
            StatusCode = statusCode;
        }
    }
}
