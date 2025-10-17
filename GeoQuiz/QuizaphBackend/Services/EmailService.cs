using System.Net.Mail;
using System.Net.Mime;

namespace QuizaphBackend.Services
{
    public class EmailService : Microsoft.AspNetCore.Identity.UI.Services.IEmailSender, IDisposable
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {

            // create MailMessage
            var mailMessage = new MailMessage
            {
                From = new MailAddress("sporting.inn@gmail.com"),
                Subject = subject,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            // HTML references the CID
            var htmlBody = $@"
                <p>{message}</p>
                <p>
                    <img src='cid:logo' alt='Company Logo' style='width: 100px; height: auto; margin-bottom: 20px;' />
                </p>
                <p>Regards,<br>Sporting Inn</p>";
            mailMessage.Body = htmlBody;

            // Attach image as inline
            var inlineImage = new Attachment("Images/QuizaphEmailPic.jpg");
            inlineImage.ContentId = "logo";
            inlineImage.ContentDisposition!.Inline = true;
            inlineImage.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
            mailMessage.Attachments.Add(inlineImage);
            // Send
            try
            {
                await _smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                
            }
          
        }
        public void Dispose()
        {
            _smtpClient.Dispose();
        }
    }
}
