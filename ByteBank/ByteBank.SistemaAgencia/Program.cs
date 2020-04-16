using System;
using ByteBank.Modelos.dbSys;
using ByteBank.Modelos.SistemaInterno;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente("071.730.934-73", "Paulo Henrique Liberato de Souza", DateTime.Parse("26/12/1991"));
            var conta = new ContaCorrente(8380,05785,cliente);
            conta.Persistir();

            Console.ReadLine();
        }
    }
}
