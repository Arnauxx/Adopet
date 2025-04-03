using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Settings;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public class EnvioDeEmail
    {
        private IMailService CriarMailService()
        {
            MailSettings settings = Configurations.MailSetting;
            SmtpClient smtp = new()
            {
                Host = settings.Servidor,
                Port = settings.Porta,
                Credentials = new NetworkCredential(settings.Usuario, settings.Senha),
                EnableSsl = true,
                UseDefaultCredentials = false
            };
            return new SmtpClientMailService(smtp);
        }
    }
}
