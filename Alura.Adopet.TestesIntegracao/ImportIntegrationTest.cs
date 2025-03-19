using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.TestesIntegracao.Builder;

namespace Alura.Adopet.Testes
{
    public class ImportIntegrationTest
    {
        [Fact]
        public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            //Arrange
            List<Pet> listaDePets = new List<Pet>();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),
                "Lima", TipoPet.Cachorro); //"456b24f4-19e2-4423-845d-4a80e8854a41; Lima Limão;1";
            listaDePets.Add(pet);
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePets);
            var httpClientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
            var import = new Import(httpClientPet, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            await import.ExecutarAsync();
            var listaPet = await httpClientPet.ListPetsAsync();

            //Assert
            Assert.NotNull(listaPet);

        }
    }
}
