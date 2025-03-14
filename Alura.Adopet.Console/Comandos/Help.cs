using Alura.Adopet.Console.Util;
using FluentResults;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help",
    documentacao: "adopet help comando que exibe informações de ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    internal class Help : IComando
    {
        private Dictionary<string, DocComando> docs;

        public Help()
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
        }

        public Task<Result> ExecutarAsync(string[] args)
        {
            try
            {
                return Task.FromResult(Result.Ok()
                    .WithSuccess(new SuccessWithDocs(this.GerarDocumentacao(parametros: args))));
            }
            catch(Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição de documentação falhou!").CausedBy(ex.Message)));
            }
        }

        public IEnumerable<string> GerarDocumentacao(string[] parametros)
        {
            List<string> resultado = new List<string>();
            try
            {
                // se não passou mais nenhum argumento mostra help de todos os comandos
                if (parametros.Length == 1)
                {

                    foreach (var doc in docs.Values)
                    {
                        resultado.Add(doc.Documentacao);
                    }
                }
                // exibe o help daquele comando específico
                else if (parametros.Length == 2)
                {
                    string comandoASerExibido = parametros[1];
                    if (docs.ContainsKey(comandoASerExibido))
                    {
                        var comando = docs[comandoASerExibido];
                       resultado.Add(comando.Documentacao);
                    }
                    else
                    {
                        resultado.Add($"Comando não encontrado: '{comandoASerExibido}'!");
                    }
                }
                else
                {
                    resultado.Add($"Quantidade de parametros inválida!");
                }
                return resultado;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
