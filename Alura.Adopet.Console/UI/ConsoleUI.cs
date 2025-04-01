using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Results;
using Alura.Adopet.Console.Util;
using FluentResults;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Alura.Adopet.Console.UI
{
    public static class ConsoleUI
    {
        public static void ExibeResultado(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                if (result.IsFailed)
                {
                    ExibeFalha(result);
                }
                else
                {
                    ExibeSucesso(result);
                }
            }
            finally
            {
                System.Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ExibeSucesso(Result result)
        {
            var sucesso = result.Successes.First();
            switch (sucesso)
            {
                case SuccessWithPets sucess:
                    ExibirPets(sucess);
                    break;
                case SuccessWithClientes sucess:
                    ExibirClientes(sucess);
                    break;
                case SuccessWithDocs docs:
                    ExibeDocumentacao(docs); 
                    break;
            }
        }

        private static void ExibeDocumentacao(SuccessWithDocs documentacaoComando)
        {
            System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.\n");
            foreach(var doc in documentacaoComando.Documentacao)
            {
                System.Console.WriteLine(doc);
            }
        }

        private static void ExibirPets(SuccessWithPets sucess)
        {
            foreach (var pet in sucess.Data)
            {
                System.Console.WriteLine(pet);
            }
            System.Console.WriteLine(sucess.Message);

        }

        private static void ExibirClientes(SuccessWithClientes sucess)
        {
            if (sucess == null) return;
            if (sucess.Data == null) return;

            foreach (var cliente in sucess.Data)
            {
                    System.Console.WriteLine(cliente);
            }
            System.Console.WriteLine(sucess.Message);

        }

        private static void ExibeFalha(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            var error = result.Errors.First();
            System.Console.WriteLine($"Aconteceu um exceção: {error.Message}");
        }
    }
}
