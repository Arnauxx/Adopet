using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using FluentResults;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
        documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet")]
    public class List : IComando
    {

        private readonly HttpClientPet clientPet;

        public List(HttpClientPet clientPet)
        {
            this.clientPet = clientPet;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                return await this.MostrarListaDePetsCadastradasAsync();
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Erro ao exibir lista!").CausedBy(ex));
            }
        }
        public async Task<Result> MostrarListaDePetsCadastradasAsync()
        {
            try
            {
                IEnumerable<Pet>? pets = await clientPet.ListPetsAsync();
                if (pets is not null)
                {
                    return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Lista de pets consultada com sucesso!"));
                }
                else
                {
                    throw new Exception("Erro ao obter lista de pets");
                }
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(ex));
            }
        }
    }
}
