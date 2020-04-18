using System;
using ByteBank.Modelos.SistemaInterno;
using System.Linq;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = Cliente.GetCliente("123");
            cliente.Nome = "Paulo Henrique Liberato de Souza";           
            cliente.Update();

            Console.ReadLine();
        }
    }
}
