using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos.Abstracoes;
using Alura.Adopet.Console.UI;
using FluentResults;

namespace Alura.Adopet.Console.Servicos.Arquivos
{
    public class LeitorDeArquivoCSV: ILeitorDeArquivos<Pet>
    {
        private string caminhoDoArquivoASerLido;
        public LeitorDeArquivoCSV(string caminhoDoArquivoASerLido)
        {
            this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
        }

        public virtual IEnumerable<Pet> RealizaLeituraDoArquivo()
        {
            try
            {
                if (!string.IsNullOrEmpty(caminhoDoArquivoASerLido))
                {
                    List<Pet> listaDePet = new List<Pet>();
                    using (StreamReader sr = new StreamReader(caminhoDoArquivoASerLido))
                        while (!sr.EndOfStream)
                        {
                            // separa linha usando ponto e vírgula
                            string[] propriedades = sr.ReadLine().Split(';');
                            // cria objeto Pet a partir da separação
                            Pet pet = new Pet(Guid.Parse(propriedades[0]),
                              propriedades[1],
                              int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                             );
                            listaDePet.Add(pet);
                        }
                    return listaDePet;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ConsoleUI.ExibeResultado(Result.Fail(ex.Message));
                return null;
            }
        }
    }
}
