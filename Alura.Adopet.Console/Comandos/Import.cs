using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando,IDepoisDaExecucao
    {

        private readonly IApiService<Pet> clientPet;
        private readonly ILeitorDeArquivos<Pet> leitorDeArquivo;

        public Import(IApiService<Pet> clientPet, ILeitorDeArquivos<Pet> leitorDeArquivo)
        {
            this.clientPet = clientPet;
            this.leitorDeArquivo = leitorDeArquivo;
        }

        public event Action<Result>? DepoisDaExecucao;

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitorDeArquivo.RealizaLeituraDoArquivo();
                foreach (var pet in listaDePet)
                {
                    await clientPet.CreateAsync(pet);
                }
                var resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação realizada com sucesso!"));
                DepoisDaExecucao?.Invoke(resultado);
                return resultado;
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
            }
        }
    }
}
