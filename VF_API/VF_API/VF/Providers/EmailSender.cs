﻿using System.Threading.Tasks;

using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using VF_API.Options;
using VF_API.Exceptions;
using VF_API.Resources;
using System;
using Microsoft.Extensions.Localization;

namespace VF_API.Providers
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions emailOptions;
        private readonly IStringLocalizer<Account> localizerAccount;

        /// <summary>
        /// Constructor of email sender
        /// </summary>
        /// <param name="emailOptions"></param>
        public EmailSender(IOptions<EmailOptions> emailOptions,IStringLocalizer<Account> localizerAccount)
        {
            this.emailOptions = emailOptions.Value;
            this.localizerAccount = localizerAccount;
        }

        /// <summary>
        /// Send email async
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            Execute(email, subject, message).Wait();
            return Task.FromResult(0);
        }

        /// <summary>
        /// Execute send email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task Execute(string email, string subject, string body)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(emailOptions.FromEmail));
                message.To.Add(new MailboxAddress(email));
                message.Subject = subject;

                BodyBuilder bodyBuilder = new BodyBuilder { HtmlBody = body };
                message.Body = bodyBuilder.ToMessageBody();

                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect(emailOptions.SmtpServer, emailOptions.Port);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailOptions.Username, emailOptions.Password);
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {
                throw new FailedSendEmailException(localizerAccount["SendPinCodeFailed"]);
            }
        }
    }
}
