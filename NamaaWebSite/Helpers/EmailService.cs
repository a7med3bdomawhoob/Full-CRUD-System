using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;




namespace PL.Helpers
{
    public class EmailService
    {

        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        //private readonly string _username = "engaabdo971@gmail.com"; Ashraf.elassaly@kharetatalenamaa.sa
        private readonly string _username = "";
        private readonly string _password = "2023@2023Sww";

        public async Task SendEmailAsync(string First,string Last,string toEmail, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(First+Last, _username));
            /*  message.To.Add(new MailboxAddress("", toEmail));*/
           // ahmed - saad1997@hotmail.com
            message.To.Add(new MailboxAddress("", "mawhoobahmed99@gmail.com"));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = body
            };



            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync("namaaconsult001@gmail.com", "rcur zype uyfi ufel");   //From
                //await client.AuthenticateAsync("engaabdo971@gmail.com", "rcur zype uyfi ufel");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }













    }
}