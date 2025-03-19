using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Alura.Adopet.Console.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Servicos
{
    public class LeitorDeArquivosCSVTest : IDisposable
    {
        private string caminhoArquivo;
        public LeitorDeArquivosCSVTest()
        {
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";
            File.WriteAllText("lista.csv", linha);
            caminhoArquivo = Path.GetFullPath("lista.csv");
        }

        [Fact]
        public void QuandoArquivoExistenteDeveRetornarUmaListaDePets()
        {
            //Arrange            
            //Act
            var listaDePets = new LeitorDeArquivoCSV(caminhoArquivo).RealizaLeituraDoArquivo()!;
            //Assert
            Assert.NotNull(listaDePets);
            Assert.Single(listaDePets);
            Assert.IsType<List<Pet>?>(listaDePets);
        }
        [Fact]
        public void QuandoArquivoNaoExistenteDeveRetornarNulo()
        {
            //Arrange
            //Act
            var listaDePets = new LeitorDeArquivoCSV(string.Empty).RealizaLeituraDoArquivo();

            //Assert
            Assert.Null(listaDePets);
        }

        [Fact]
        public void QuandoArquivoForNuloDeveRetornarNulo()
        {
            //Arrange
            //Act
            var listaDePets = new LeitorDeArquivoCSV(null).RealizaLeituraDoArquivo();

            //Assert
            Assert.Null(listaDePets);
        }

        public void Dispose()
        {
            File.Delete(caminhoArquivo);
        }
    }
}
