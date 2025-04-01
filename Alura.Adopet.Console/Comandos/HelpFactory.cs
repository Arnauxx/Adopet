namespace Alura.Adopet.Console.Comandos
{
    public class HelpFactory: IComandoFactory
    {
        public IComando? CriarComando(string[] argumentos)
        {
            var comandoASerExibido = argumentos.Length == 2 ? argumentos[1] : null;
            return new Help(comandoASerExibido);
        }
    }
}
