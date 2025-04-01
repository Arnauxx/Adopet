using Alura.Adopet.Console.Comandos;
using System.Reflection;

namespace Alura.Adopet.Console.Extensions
{
    public static class ComandosExtensions
    {
        public static Type? GetTipoComando(this Assembly assembly, string instrucao)
        {
            return assembly.GetTypes() // lista de tipos
                                       // filtrar apenas os tipos concretos que são comandos
                .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando))) // IComando comando = t
                .FirstOrDefault(t => t.GetCustomAttributes<DocComando>()
                .Any(d => d.Instrucao.Equals(instrucao))); //recuperar apenas aquele que atende à instrução "instrucao"
        }
    }
}
