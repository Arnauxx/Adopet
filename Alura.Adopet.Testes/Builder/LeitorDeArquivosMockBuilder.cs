﻿using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;
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
        public static Mock<LeitorDeArquivo> GetMock(List<Pet> listaDePets)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeituraDoArquivo()).Returns(listaDePets);

            return leitorDeArquivo;
        }
    }
}
