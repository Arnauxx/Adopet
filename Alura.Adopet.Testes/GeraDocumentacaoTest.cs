﻿using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Testes
{
    public class GeraDocumentacaoTest
    {
        [Fact]
        public void QuandoExistemComandosDeveRetornarDicionarioNaoVazio()
        {
            //Arrange
            Assembly assemblyComOTipoDocComando = Assembly.GetAssembly(typeof(DocComando))!;
            //Act
            Dictionary<string, DocComando> dicionario = DocumentacaoDoSistema.ToDictionary(assemblyComOTipoDocComando);
            //Assert
            Assert.NotNull(dicionario);
            Assert.NotEmpty(dicionario);
            Assert.Equal(5, dicionario.Count());
        }
    }
}
