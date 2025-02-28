using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
        documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet")]
    internal class List:IComando
    {
        public async Task ExecutarAsync(string[] args)
        {
            await this.MostrarListaDePetsCadastradasAsync();
        }

        public async Task MostrarListaDePetsCadastradasAsync()
        {
            var httpListPets = new HttpClientPet();
            IEnumerable<Pet>? pets = await httpListPets.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
