using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Console.Comandos
{
    public class ShowFactory: IComandoFactory
    {
        public IComando? CriarComando(string[] argumentos)
        {
            var leitorDeArquivosShow = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
            if (leitorDeArquivosShow is null) { return null; }
            return new Show(leitorDeArquivosShow);
        }
    }
}
