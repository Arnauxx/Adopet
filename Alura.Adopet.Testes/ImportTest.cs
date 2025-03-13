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
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriaMock(listaDePets);

            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());

            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            //Act
            await import.ExecutarAsync(args);

            //Assert
            httpClientPet.Verify(_=>_.CreatePetAsync(It.IsAny<Pet>()), Times.Never());
        }
    }
}
