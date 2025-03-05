using Alura.Adopet.Console.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    internal class ComandosDoSistema
    {
        private static HttpClientPet clientPet = new HttpClientPet(new AdopetAPIClientFactory().CreateClient("adopet"));
        private Dictionary<string, IComando> comandosDoSistema = new()
        {
            {"help", new Help()},
            {"import", new Import(clientPet)},
            {"list", new List(clientPet)},
            {"show", new Show()},
        };

        public IComando? this[string key] => comandosDoSistema.ContainsKey(key) ? comandosDoSistema[key] : null;
    }
}
