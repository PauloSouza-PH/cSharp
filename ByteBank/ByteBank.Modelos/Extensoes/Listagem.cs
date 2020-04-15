using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Extensoes
{
    public static class Listagem
    {
        public static void Listar(this object texto)
        {
            Console.WriteLine(texto);
        }
    }
}
