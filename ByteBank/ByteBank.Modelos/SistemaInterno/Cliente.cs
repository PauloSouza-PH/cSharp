using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.SistemaInterno
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; private set; }
        public DateTime Nascimento { get; private set; }
        public int Idade
        {
            get
            {
                return Nascimento.Year;
            }
            private set {
                return;
            }
        }

        public Cliente(string cpf, string nome, DateTime nascimento)
        {
            CPF = cpf ?? throw new ArgumentOutOfRangeException(nameof(cpf));
            Nome = nome;
            Nascimento = nascimento;
        }

       

        public override string ToString()
        {
            return $"Cliente:\t{Nome}\nCPF:\t{CPF}\nIdade:\t{Idade}";
        }

    }
}
