using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Alura.Adopet.Console.Servicos.Arquivos;
public class LeitorDeArquivoJson: ILeitorDeArquivos
{
    private string caminhoArquivo;

    public LeitorDeArquivoJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public virtual IEnumerable<Pet> RealizaLeituraDoArquivo()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream)??Enumerable.Empty<Pet>();
    }
}

