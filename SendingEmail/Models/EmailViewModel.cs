namespace SendingEmail.Models
{
    public class EmailViewModel
    {
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
        public string ReceiverEmailAddress { get; set; }
        public string SenderEmailAddress { get; set; }
        public string SenderPassword { get; set; }
        public string SmtpHostServer { get; set; }
        public int SmtpPort { get; set; }
    }
}