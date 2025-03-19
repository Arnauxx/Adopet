using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;
using Moq;

namespace Alura.Adopet.Testes.Comandos
{
    public class ImportTest
    {
        [Fact]
        public async void QuandoListaVaziaNaoDeveChamarCreatePetAsync()
        {
            //Arrange
            List<Pet> listaDePets = new List<Pet>();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePets);
            var httpClientPet = HttpClientPetMockBuilder.GetMock();
            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            await import.ExecutarAsync();

            //Assert
            httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never());
        }

        [Fact]
        public async void QuandoArquivoNaoExistirDeveGerarFalha()
        {
            //Arrange
            List<Pet> listaDePets = new List<Pet>();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePets);
            leitorDeArquivo.Setup(_ => _.RealizaLeituraDoArquivo()).Throws<FileNotFoundException>();
            var httpClientPet = HttpClientPetMockBuilder.GetMock();
            string[] args = { "import", "lista.csv" };
            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

            //Act
            var resultado = await import.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsFailed);
        }

        [Fact]
        public async Task QuandoPetEstiverNoArquivoDeveSerImportado()
        {
            //Arrange
            List<Pet> listaDePets = new List<Pet>();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"), "Lima", TipoPet.Cachorro);
            listaDePets.Add(pet);
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePets);
            var httpClientPet = HttpClientPetMockBuilder.GetMock();
            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            var resultado = await import.ExecutarAsync();

            //Assert
            Assert.True(resultado.IsSuccess);
            var sucesso = (SuccessWithPets)resultado.Successes[0];
            Assert.Equal("Lima", sucesso.Data.First().Nome);
        }
    }
}
