using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Testes
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
        {
            //Arrange
            var httpClient = new HttpClient();
            var clientePet = new HttpClientPet(httpClient);

            //Act
            var lista = await clientePet.ListPetsAsync();

            //Assert
            Assert.NotNull(lista);
            Assert.NotEmpty(lista);

        }

        [Fact]
        public async Task QuandoAPIForaDeveRetornarUmaExcecao()
        {
            //Arrange
            var httpClient = new HttpClient();
            var clientePet = new HttpClientPet(httpClient);

            //Act+Assert
            await Assert.ThrowsAnyAsync<Exception>(() => clientePet.ListPetsAsync());
        }
    }
}