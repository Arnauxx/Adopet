using Alura.Adopet.Console.Modelos;
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
        public Task<Result> ExecutarAsync()
        {
            try
            {
                return this.ExibeConteudoDoArquivo();
            }
            catch (Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error("Erro exibir o conteúdo do arquivo").CausedBy(ex.Message)));
            }
        }

        private Task<Result> ExibeConteudoDoArquivo()
        {
            try
            {
               var listaDePet = leitorDeArquivo.RealizaLeituraDoArquivo();
               return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Conteudo do arquivo exibido com sucesso!")));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
