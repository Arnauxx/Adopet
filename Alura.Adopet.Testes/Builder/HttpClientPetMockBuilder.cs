using Alura.Adopet.Console.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes.Builder
{
    internal static class HttpClientPetMockBuilder
    {

        public static Mock<HttpClientPet> GetMock()
        {
            return new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
        }
    }
}
