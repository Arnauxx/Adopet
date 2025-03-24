using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Servicos.Arquivos;
public class ClienteDoJson : LeitorDeArquivoJson<Cliente>
{
    public ClienteDoJson(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
    {
    }

}