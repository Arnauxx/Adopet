using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Util;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "show",
        documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
    internal class Show:IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            this.ExibeConteudoDoArquivo(caminhoDoArquivoASerExibido: args[1]);
            return Task.CompletedTask;
        }

        private void ExibeConteudoDoArquivo(string caminhoDoArquivoASerExibido)
        {
            using (StreamReader sr = new StreamReader(caminhoDoArquivoASerExibido))
            {
                List<Pet> listaDePet = new List<Pet>();
                LeitorDeArquivo leitorDeArquivo = new LeitorDeArquivo();
                System.Console.WriteLine("----- Serão importados os dados abaixo -----");
                listaDePet = leitorDeArquivo.RealizaLeituraDoArquivo(caminhoDoArquivoASerExibido);
                foreach (Pet pet in listaDePet)
                {
                    System.Console.WriteLine(pet.ToString());
                }
            }
        }


    }
}
