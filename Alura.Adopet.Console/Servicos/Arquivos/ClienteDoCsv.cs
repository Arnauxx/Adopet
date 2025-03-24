using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class ClienteDoCsv : LeitorDeArquivoCSV<Cliente>
    {
        public ClienteDoCsv(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
        {
        }

        public override Cliente CriarDaLinhaCsv(string linha)
        {
            string[] propriedades = linha.Split(';');

            return new Cliente(
                id: Guid.Parse(propriedades[0]),
                nome: propriedades[1],
                email: propriedades[2]
                );
        }
    }
}
