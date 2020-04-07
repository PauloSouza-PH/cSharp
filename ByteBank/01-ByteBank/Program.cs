using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente("Teste pereira", "333.333.333-33", Convert.ToDateTime("26/12/1991"));
            ContaCorrente conta = new ContaCorrente( cliente, 8380, 057854 );

            Console.ReadLine();
        }
    }
}
