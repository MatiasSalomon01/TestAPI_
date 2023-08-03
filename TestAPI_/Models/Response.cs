    namespace TestAPI_.Models
{
    public class Response
    {
        public int Status { get; set; }
        public dynamic Message { get; set; }
        public DateTime Date { get; set; }

        public Response(int status, dynamic msg, DateTime date)
        {
            Status = status;
            Message = msg;
            Date = date;
        }
    }
}
