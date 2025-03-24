using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.UI;
using FluentResults;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public abstract class LeitorDeArquivoCSV<T>: ILeitorDeArquivos<T>
    {
        private string caminhoDoArquivoASerLido;
        public LeitorDeArquivoCSV(string caminhoDoArquivoASerLido)
        {
            this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
        }

        public virtual IEnumerable<T> RealizaLeituraDoArquivo()
        {
            try
            {
                if (string.IsNullOrEmpty(caminhoDoArquivoASerLido)) return null;
                
                    List<T> lista = new List<T>();
                    using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
                        while (!sr.EndOfStream)
                        {
                            string? linha = sr.ReadLine();
                            if(linha is not null)
                            {
                                var objeto = CriarDaLinhaCsv(linha);
                                lista.Add(objeto);
                            }
                        }
                    return lista;
            }
            catch (Exception ex)
            {
                ConsoleUI.ExibeResultado(Result.Fail(ex.Message));
                return null;
            }
        }

        public abstract T CriarDaLinhaCsv(string linha);
    }
}
