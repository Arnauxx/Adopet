using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using Alura.Adopet.Testes.Builder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
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
            await import.ExecutarAsync(args);

            //Assert
            httpClientPet.Verify(_=>_.CreatePetAsync(It.IsAny<Pet>()), Times.Never());
        }

        [Fact]
        public async void QuandoArquivoDeImportacaoNaoExistirDeveGerarException()
        {
            //Arrange
            List<Pet> listaDePets = new List<Pet>();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(listaDePets);
            leitorDeArquivo.Setup(_=>_.RealizaLeituraDoArquivo()).Throws<FileNotFoundException>();
            var httpClientPet = HttpClientPetMockBuilder.GetMock();
            string[] args = { "import", "lista.csv" };
            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);

            //Act + Assert
            await Assert.ThrowsAnyAsync<Exception>(() => import.ExecutarAsync(args));
        }
    }
}
