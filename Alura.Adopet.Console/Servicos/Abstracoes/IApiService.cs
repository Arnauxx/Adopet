using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Abstracoes
{
    public interface IApiService
    {
        Task CreatePetAsync(Pet pet);
        Task<IEnumerable<Pet>?> ListPetsAsync();
    }
}
