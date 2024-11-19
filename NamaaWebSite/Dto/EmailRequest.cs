namespace PL.Dto
{
    public class EmailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }
}
