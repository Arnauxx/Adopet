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
        private List<Pet> listaDePet;

        public Show(LeitorDeArquivo leitorDeArquivo)
        {
            this.leitorDeArquivo = leitorDeArquivo;
        }
        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                this.ExibeConteudoDoArquivo();
                if (listaDePet.Count > 0)
                {
                    return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Conteudo do arquivo exibido com sucesso!")));
                }
                else
                {
                    throw new Exception("Não existe registros no arquivo informado!");
                }
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
                listaDePet = leitorDeArquivo.RealizaLeituraDoArquivo();
                //foreach (Pet pet in listaDePet)
                //{
                //    //Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, pet.ToString()));
                //    //System.Console.WriteLine(pet.ToString());
                //}
                //Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importação realizada com sucesso!"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
