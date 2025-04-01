using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos
{
    public class ImportFactory: IComandoFactory
    {
        public IComando? CriarComando(string[] argumentos)
        {
            var httpClientPet = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
            var leitorDeArquivos = LeitorDeArquivosFactory.CreatePetFrom(argumentos[1]);
            if (leitorDeArquivos is null) { return null; }
            return new Import(httpClientPet, leitorDeArquivos);
        }
    }
}
