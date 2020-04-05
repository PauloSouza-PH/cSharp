using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente("Teste pereira", "333.333.333-33", DateTime.Parse("19911226"));
            ContaCorrente conta = new ContaCorrente( cliente, 8380, 057854 );

            Console.ReadLine();
        }
    }
}
