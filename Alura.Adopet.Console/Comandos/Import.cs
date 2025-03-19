using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "import",
        documentacao: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {

        private readonly IApiService clientPet;
        private readonly ILeitorDeArquivos leitorDeArquivo;

        public Import(IApiService clientPet, ILeitorDeArquivos leitorDeArquivo)
        {
            this.clientPet = clientPet;
            this.leitorDeArquivo = leitorDeArquivo;
        }

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
                    await clientPet.CreatePetAsync(pet);
                }
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação realizada com sucesso!"));
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
            }
        }
    }
}
