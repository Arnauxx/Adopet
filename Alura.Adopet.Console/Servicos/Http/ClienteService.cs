using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Alura.Adopet.Console.Servicos.Http;
public class ClienteService : IApiService<Cliente>
{
    private HttpClient client;

    public ClienteService(HttpClient client)
    {
        this.client = client;
    }
    public Task CreateAsync(Cliente cliente)
    {
        return client.PostAsJsonAsync("cliente/add", cliente);
    }

    public async Task<IEnumerable<Cliente>?> ListAsync()
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("cliente/list");

            if (response.IsSuccessStatusCode)
            {
                var clientes = await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
                return clientes;
            }
            else
            {
                System.Console.WriteLine($"Erro na requisição: {response.StatusCode}");
                var errorContent = await response.Content.ReadAsStringAsync();
                System.Console.WriteLine($"Conteúdo do erro: {errorContent}");
                return null;
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Ocorreu uma exceção: {ex.Message}");
            return null;
        }

    }
}