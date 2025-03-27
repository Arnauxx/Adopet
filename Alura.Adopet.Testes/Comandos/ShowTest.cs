using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Testes.Builder;

namespace Alura.Adopet.Testes.Comandos
{
    public class ShowTest
    {
        [Fact]
        public async Task QuandoArquivoExistenteDeveRetornarMensagemDeSucesso()
        {
            //arrange
            List<Pet>? listaDePet = new();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"), "Lima", TipoPet.Cachorro);
            listaDePet.Add(pet);
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock<Pet>(listaDePet);
            leitorDeArquivo.Setup(_ => _.RealizaLeituraDoArquivo());
            var objShow = new Show(leitorDeArquivo.Object);

            //act
            var retorno = await objShow.ExecutarAsync();

            //Assert
            var resultado = (SuccessWithPets)retorno.Successes[0];
            Assert.Equal("Conteudo do arquivo exibido com sucesso!", resultado.Message);
        }
    }
}
