using System.Net;

namespace TestAPI_.Models
{
    public class ErrorDetails
    {
        public HttpStatusCode statusCode{ get; set; }
        public string Message { get; set; }
        public dynamic StackTrace { get; set; }
    }
}
