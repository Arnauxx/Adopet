using Alura.Adopet.Console.Comandos;
using Alura.Adopet.Console.Servicos;

ComandosDoSistema comandos = new();

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string comando = args[0].Trim();
    IComando? comandoASerExecutado = comandos[comando];
    if (comandoASerExecutado is not null) await comandoASerExecutado.ExecutarAsync(args);
    else Console.WriteLine("Comando inválido!");
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}