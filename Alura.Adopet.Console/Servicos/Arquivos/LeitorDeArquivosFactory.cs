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
                    return new PetsDoCsv(caminhoDoArquivo);
                case ".json":
                    return new LeitorDeArquivoJson<Pet>(caminhoDoArquivo);
                default: return null;
            }
        }

        public static ILeitorDeArquivos<Cliente>? CreateClienteFrom(string caminhoDoArquivo)
        {
            var extensao = Path.GetExtension(caminhoDoArquivo);

            switch (extensao)
            {
                case ".csv":
                    return new ClienteDoCsv(caminhoDoArquivo);
                case ".json":
                    return new LeitorDeArquivoJson<Cliente>(caminhoDoArquivo);
                default: return null;
            }
        }
    }
}
