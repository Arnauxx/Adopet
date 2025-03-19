using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<LeitorDeArquivoCSV> GetMock(List<Pet> listaDePets)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivoCSV>(MockBehavior.Default, It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeituraDoArquivo()).Returns(listaDePets);

            return leitorDeArquivo;
        }
    }
}
