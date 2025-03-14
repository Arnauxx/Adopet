using Alura.Adopet.Console.Util;
using FluentResults;

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

        private static void ExibeFalha(Result result)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            var error = result.Errors.First();
            System.Console.WriteLine($"Aconteceu um exceção: {error.Message}");
        }
    }
}
