using Alura.Adopet.Console.Servicos.Abstracoes;
using Moq;

namespace Alura.Adopet.Testes.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<ILeitorDeArquivos<T>> GetMock<T>(List<T> lista)
    {
        var leitorDeArquivo = new Mock<ILeitorDeArquivos<T>>(MockBehavior.Default
            );

        leitorDeArquivo.Setup(_ => _.RealizaLeituraDoArquivo()).Returns(lista);

        return leitorDeArquivo;
    }
}