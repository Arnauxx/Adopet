using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Settings;
using FluentResults;
using System.Net;
using System.Net.Mail;

namespace Alura.Adopet.Console.Servicos.Mail
{
    public static class EnvioDeEmail
    {
        private static IMailService CriarMailService()
        {
            MailSettings settings = Configurations.MailSetting;
            SmtpClient smtp = new()
            {
                Host = settings.Servidor,
                Port = settings.Porta,
                Credentials = new NetworkCredential(settings.Usuario, settings.Senha),
                EnableSsl = false,
                UseDefaultCredentials = false
            };
            smtp.SendCompleted += (s, e) => smtp.Dispose();
            smtp.EnableSsl = true;
            return new SmtpClientMailService(smtp);
        }

        public static void Disparar(Result resultado)
        {
            ISuccess? success = resultado.Successes.FirstOrDefault();
            if (success is null) return;
            if (success is SuccessWithPets sucesso)
            {
                var emailService = CriarMailService();
                emailService.SendmailAssync(
                    rementente: "no-reply@adopet.com.br",
                    titulo: $"[Adopet] {sucesso.Message}",
                    corpo: $"Foram importados {sucesso.Data.Count()} pets.",
                    destinatario: "arnauxstevan@gmail.com"
                    );
            }
        }
    }
}
