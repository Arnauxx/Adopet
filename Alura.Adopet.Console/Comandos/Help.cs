using Alura.Adopet.Console.Util;
using FluentResults;
using System.Reflection;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "help",
    documentacao: "adopet help comando que exibe informações de ajuda. \n" +
        "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
    public class Help : IComando
    {
        private Dictionary<string, DocComando> docs;
        private string? comando;

        public Help(string? comando)
        {
            docs = DocumentacaoDoSistema.ToDictionary(Assembly.GetExecutingAssembly());
            this.comando = comando;
        }

        public Task<Result> ExecutarAsync()
        {
            try
            {
                return Task.FromResult(Result.Ok()
                    .WithSuccess(new SuccessWithDocs(this.GerarDocumentacao())));
            }
            catch(Exception ex)
            {
                return Task.FromResult(Result.Fail(new Error("Exibição de documentação falhou!").CausedBy(ex.Message)));
            }
        }

        public IEnumerable<string> GerarDocumentacao()
        {
            List<string> resultado = new List<string>();
            try
            {
                // se não passou mais nenhum argumento mostra help de todos os comandos
                if (this.comando is null)
                {

                    foreach (var doc in docs.Values)
                    {
                        resultado.Add(doc.Documentacao);
                    }
                }
                // exibe o help daquele comando específico
                else
                {
                    if (docs.ContainsKey(this.comando))
                    {
                        var comando = docs[this.comando];
                       resultado.Add(comando.Documentacao);
                    }
                    else
                    {
                        resultado.Add($"Comando não encontrado: '{this.comando}'!");
                        throw new ArgumentException(resultado[0]);
                    }
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
