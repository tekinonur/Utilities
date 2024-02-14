using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Utilities.Models;
using Utilities.Services.MailService.Models;

namespace Utilities.Services.MailService
{
    public class MailService : IMailService
    {
        private readonly MailSetting _mailSetting;

        private readonly ILogger<MailService> _logger;

        public MailService(
            IOptions<MailSetting> mailSetting,
            ILogger<MailService> logger)
        {
            _mailSetting = mailSetting.Value;
            _logger = logger;
        }

        public async Task SendEmail(MailRequest mailRequest)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_mailSetting.DisplayName),
                Subject = mailRequest.Subject,
                Body = mailRequest.Body
            };
            mailRequest.ToEmail.ForEach(x => message.To.Add(new MailAddress(x)));

            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        message.Attachments.Add(new Attachment(new MemoryStream(fileBytes), file.FileName));
                    }
                }
            }

            var smtp = new SmtpClient(_mailSetting.Host, _mailSetting.Port);
            smtp.Credentials = new NetworkCredential(_mailSetting.Mail, _mailSetting.Password);

            try
            {
                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "EmailService: Unhandled Exception for Request {@Request}", mailRequest);
            }

            _logger.LogWarning($"Sending email to {string.Join(",", mailRequest.ToEmail)} from {_mailSetting.Mail} with subject {mailRequest.Subject}.");
        }
    }
}
