using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Http;
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

        public static Mock<PetService> GetMock()
        {
            return new Mock<PetService>(MockBehavior.Default, It.IsAny<HttpClient>());
        }

        public static Mock<PetService> GetMockList(List<Pet> lista)
        {
            var httpClientPet = new Mock<PetService>(MockBehavior.Default,
                It.IsAny<HttpClient>());
            httpClientPet.Setup(_ => _.ListAsync())
                .ReturnsAsync(lista);
            return httpClientPet;
        }
    }
}
