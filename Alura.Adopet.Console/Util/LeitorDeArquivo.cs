﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.Adopet.Console.Modelos;

namespace Alura.Adopet.Console.Util
{
    public class LeitorDeArquivo
    {
        public List<Pet> RealizaLeituraDoArquivo(string caminhoDoArquivoASerLido)
        {
            if (!String.IsNullOrEmpty(caminhoDoArquivoASerLido))
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
    }
}
