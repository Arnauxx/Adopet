using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
        documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    public class Show : IComando
    {
        private readonly LeitorDeArquivo leitorDeArquivo;

        public Show(LeitorDeArquivo leitorDeArquivo)
        {
            this.leitorDeArquivo = leitorDeArquivo;
        }
        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                this.ExibeConteudoDoArquivo();
                return Task.FromResult(Result.Ok());
            }
            catch (Exception ex)
            {
               return Task.FromResult(Result.Fail(new Error("Erro exibir o conteúdo do arquivo").CausedBy(ex.Message)));
            }
        }

        private void ExibeConteudoDoArquivo()
        {
            try
            {
                System.Console.WriteLine("----- Serão importados os dados abaixo -----");
                var listaDePet = leitorDeArquivo.RealizaLeituraDoArquivo();
                foreach (Pet pet in listaDePet)
                {
                    System.Console.WriteLine(pet.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
