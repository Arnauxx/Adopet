using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public static class LeitorDeArquivosFactory
    {
        public static ILeitorDeArquivos<Pet>? CreatePetFrom(string caminhoDoArquivo)
        {
            var extensao = Path.GetExtension(caminhoDoArquivo);

            switch (extensao)
            {
                case ".csv":
                    return new LeitorDeArquivoCSV(caminhoDoArquivo);
                case ".json":
                    return new LeitorDeArquivoJson(caminhoDoArquivo);
                default: return null;
            }
        }
    }
}
