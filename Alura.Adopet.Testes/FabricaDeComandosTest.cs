using Alura.Adopet.Console.Comandos;

namespace Alura.Adopet.Testes
{
    public class FabricaDeComandosTest
    {
        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImport()
        {
            //Arrange
            string[] argumentos = { "import", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(argumentos);
            //Assert
            Assert.IsType<Import>(comando);
        }

        [Fact]
        public void DadoUmParametroInvalidoDeveRetornarNull()
        {
            //Arrange
            string[] argumentos = { "invalid", "lista.csv" };
            //Act
            var comando = FabricaDeComandos.CriarComando(argumentos);
            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosNullDeveRetornarNull()
        {
            //Arrange
            //Act
            var comando = FabricaDeComandos.CriarComando(null);
            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosVazioDeveRetornarNull()
        {
            //Arrange
            string[] argumentos = { };
            //Act
            var comando = FabricaDeComandos.CriarComando(argumentos);
            //Assert
            Assert.Null(comando);
        }
    }
}
