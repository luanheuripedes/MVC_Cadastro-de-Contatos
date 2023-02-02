using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;

namespace ControleDeContatos.Helper.Email
{
    //PARA 
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> Enviar(string emailEndereco, string assunto, string mensagem)
        {
            try
            {

                var host = _configuration["EmailSettings:SmtpServer"];
                var nome = _configuration["EmailSettings:Name"];
                var userName = _configuration["EmailSettings:From"];
                var senha = _configuration["EmailSettings:Password"];
                Int32.TryParse(_configuration["EmailSettings:Port"], out int porta);

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(nome, userName));
                message.To.Add(new MailboxAddress("Usuario", emailEndereco));
                message.Subject = assunto;
                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = mensagem
                };

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(host, porta, true);

                    client.AuthenticationMechanisms.Remove("XOUATH2");

                    await client.AuthenticateAsync(userName, senha);

                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);

                    return true;
                }


            }
            catch (Exception)
            {
                //gravar log de erro ao enviar e-mail
                return false;
            }
        }
    }
}
