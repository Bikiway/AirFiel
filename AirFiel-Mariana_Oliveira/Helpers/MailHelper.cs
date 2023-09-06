﻿using Microsoft.Extensions.Configuration;
using MailKit.Net.Smtp;
using System;
using MimeKit;

namespace AirFiel_Mariana_Oliveira.Helpers
{
    public class MailHelper : IMailHelper
    {
        private readonly IConfiguration _configuration;
        public MailHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Response SendEmail(string to, string subject, string body)
        {
            var nameFrom = _configuration["Mail:NameFrom"];
            var from = _configuration["Mail:From"];
            var smtp = _configuration["Mail:Smtp"];
            var port = _configuration["Mail:Port"];
            var password = _configuration["Mail:Password"];

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(nameFrom, from));
            message.To.Add(new MailboxAddress(to, to)); //PQ não se sabe o nome de utilizador
            message.Subject = subject; //Assunto

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = body, //Recebe o html no email
            };
            message.Body = bodyBuilder.ToMessageBody();


            //Mandar o email
            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(smtp, int.Parse(port), false);
                    client.Authenticate(from, password);
                    client.Send(message);
                    client.Disconnect(true);
                }

            }

            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.ToString()
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }
    }
}
