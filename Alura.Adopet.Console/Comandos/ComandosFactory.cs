using Alura.Adopet.Console.Extensions;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    public static class ComandosFactory
    {
        public static IComando? CriarComando(string[] argumentos)
        {
            if ((argumentos is null) || (argumentos.Length == 0)) return null;
            var comando = argumentos[0];
            Type? tipoRetornado = Assembly.GetExecutingAssembly().GetTipoComando(comando);
            switch (comando.ToLower())
            {
                case "import":
                    return new ImportFactory().CriarComando(argumentos);

                case "import-clientes":
                    return new ImportClientesFactory().CriarComando(argumentos);

                case "list":
                    return new ListFactory().CriarComando(argumentos);

                case "show":
                    return new ShowFactory().CriarComando(argumentos);

                case "help":
                    return new HelpFactory().CriarComando(argumentos);

                default:
                    return null;
            }
        }
    }
}
