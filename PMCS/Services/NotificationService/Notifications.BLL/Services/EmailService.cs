﻿using AutoMapper;
using Notifications.BLL.Interfaces.Services;
using Notifications.BLL.Models.DTOs;
using Notifications.BLL.Models.Payloads;
using Notifications.BLL.Resources.Constants;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Notifications.BLL.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMapper _mapper;

        public EmailService(IMapper mapper)
        {
            ArgumentNullException.ThrowIfNull(mapper);

            _mapper = mapper;
        }

        public async Task SendNotification(EmailNotification notification)
        {
            var payload = _mapper.Map<EmailNotificationPayload>(notification);

            var message = CreateMailMessage(payload);
            var smtpClient = ConfigureSmtpClient();

            await smtpClient.SendMailAsync(message);
        }

        private static SmtpClient ConfigureSmtpClient()
        {
            var smtpClient = new SmtpClient(EmailConfiguration.SMTP_HOST_GMAIL);

            smtpClient.EnableSsl = Boolean.Parse(EmailConfiguration.ENABLE_SSL);
            smtpClient.UseDefaultCredentials = Boolean.Parse(EmailConfiguration.USE_DEFAULT_CRIDENTIALS);
            smtpClient.Credentials = new NetworkCredential(EmailConfiguration.SENDER_EMAIL, EmailConfiguration.SENDER_PASSWORD);
            smtpClient.Port = Int32.Parse(EmailConfiguration.SMTP_PORT_GMAIL);

            return smtpClient;
        }

        private static MailMessage CreateMailMessage(EmailNotificationPayload payload)
        {
            MailMessage message = new MailMessage();

            message.To.Add(new MailAddress(payload.ReceiverEmailAddress!));
            message.From = new MailAddress(EmailConfiguration.SENDER_EMAIL, EmailConfiguration.SENDER_NAME);
            message.Subject = payload.Subject;
            message.IsBodyHtml = Boolean.Parse(EmailConfiguration.IS_BODY_HTML);
            message.Body = message.IsBodyHtml ? GenerateHtmlMessage(payload) : GenerateTextMessage(payload);

            return message;
        }

        private static string GenerateHtmlMessage(EmailNotificationPayload payload)
        {
            StringBuilder template = new StringBuilder();

            template.AppendLine($"{Phrases.Greeting}");
            template.AppendLine($"<p>{payload.Message}</p>");
            template.AppendLine($"<p>{Phrases.Goodbye}</p>");

            return template.ToString();
        }

        private static string GenerateTextMessage(EmailNotificationPayload payload)
        {
            StringBuilder template = new StringBuilder();

            template.AppendLine($"{Phrases.Greeting}");
            template.AppendLine($"{payload.Message}");
            template.AppendLine($"{Phrases.Goodbye}");

            return template.ToString();
        }
    }
}
