namespace Alura.Adopet.Console.Servicos.Abstracoes
{
    public interface IMailService
    {
        Task SendmailAssync(string rementente,
            string destinatario,
            string titulo,
            string corpo);
    }
}
