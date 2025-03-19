using Alura.Adopet.Console.Servicos.Arquivos;

namespace Alura.Adopet.Testes.Servicos
{
    public class LeitorDeArquivosFactoryTest
    {
        private string caminhoArquivo;

        public LeitorDeArquivosFactoryTest()
        {
        }

        [Fact]
        public void QuantoExtensaoNaoSuportadaDeveRetornarNulo()
        {
            //Arrange
            caminhoArquivo = Path.GetFullPath("claro.pdf");
            //Act
            var retorno = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

            //Assert
            Assert.Null(retorno);
        }

        [Fact]
        public void QuandoExtensaoForCsvDeveRetornarTipoLeitorDeArquivoCsv()
        {
            //Arrange
            caminhoArquivo = Path.GetFullPath("lista.csv");

            //Act
            var retorno = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

            //Assert
            Assert.IsType<LeitorDeArquivoCSV>(retorno);
        }

        [Fact]
        public void QuandoExtensaoForJsonDeveRetornarTipoLeitorDeArquivoJson()
        {
            //Arrange
            caminhoArquivo = Path.GetFullPath("pets.json");

            //Act
            var retorno = LeitorDeArquivosFactory.CreatePetFrom(caminhoArquivo);

            //Assert
            Assert.IsType<LeitorDeArquivoJson>(retorno);
        }
    }
}
