using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public static class PetApartirDoCSV
    {
        public static Pet ConverteDoTexto(this string? linha)
        {
            string[]? propriedades = linha?.Split(';') ?? throw new ArgumentNullException("Texto não pode ser nulo!");

            if (string.IsNullOrEmpty(linha)) throw new ArgumentException("Texto não pode ser vazio!");

            if (propriedades.Length != 3) throw new ArgumentException("Quantidade de campos inválido!");

            bool blnIsGuid = Guid.TryParse(propriedades[0], out Guid petId);
            if (!blnIsGuid) throw new ArgumentException("Guid inválido!");

            bool blnTipoPetValido = int.TryParse(propriedades[2], out int tipoPet);
            if (!blnTipoPetValido) throw new ArgumentException("Tipo de Pet inválido");

            if (tipoPet != 0 && tipoPet != 1) throw new ArgumentException("Tipo de pet inválido");

            return new Pet(Guid.Parse(propriedades[0]),
              propriedades[1],
              int.Parse(propriedades[2]) == 0 ? TipoPet.Gato : TipoPet.Cachorro
             );
        }
    }
}
