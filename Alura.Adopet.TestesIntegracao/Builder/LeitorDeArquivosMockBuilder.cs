﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Arquivos;
using Moq;

namespace Alura.Adopet.TestesIntegracao.Builder;

internal static class LeitorDeArquivosMockBuilder
{
    public static Mock<LeitorDeArquivoCSV<Pet>> GetMock(List<Pet> listaDePet)
    {
        var leitorDeArquivo = new Mock<LeitorDeArquivoCSV<Pet>>(MockBehavior.Default,
            It.IsAny<string>());

        leitorDeArquivo.Setup(_ => _.RealizaLeituraDoArquivo()).Returns(listaDePet);

        return leitorDeArquivo;
    }
}