using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Testes.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Comandos
{
    public class ImportClientesTest
    {
        [Fact]
        public async Task QuandoClienteEstiverNoArquivoDeveSerImportado()
        {
            //arrange
            List<Cliente> clientes = new List<Cliente>();
            var cliente = new Cliente(
                id: new Guid("456b24f4-19e2-4423-845d-4a80e8854a99"),
                nome: "Jeni Entity",
                email: "jeni@example.org"
            );
            clientes.Add(cliente);
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.GetMock(clientes);
            var mockService = ApiServiceMockBuilder.GetMock<Cliente>();
            var import = new ImportClientes(mockService.Object, leitorDeArquivo.Object);

            //act
            var resultado = await import.ExecutarAsync();

            //assert
            Assert.True(resultado.IsSuccess);
            var sucesso = (SuccessWithClientes)resultado.Successes[0];
            Assert.Equal("Jeni Entity", sucesso.Data.First().Nome);
        }
    }
}
