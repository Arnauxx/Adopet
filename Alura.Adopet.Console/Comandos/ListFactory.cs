using Alura.Adopet.Console.Servicos.Http;

namespace Alura.Adopet.Console.Comandos
{
    public class ListFactory: IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(List)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            var httpClientPetList = new PetService(new AdopetAPIClientFactory().CreateClient("adopet"));
            return new List(httpClientPetList);
        }
    }
}
