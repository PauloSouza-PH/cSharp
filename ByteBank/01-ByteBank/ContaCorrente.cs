using System;

namespace ByteBank
{
    class ContaCorrente
    {
        public Cliente Cliente { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        private double _saldo = 0.1;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        public ContaCorrente(Cliente cliente, int agencia, int conta)
        {
            Cliente = cliente;
            Agencia = agencia;
            Conta = conta;
        }



    }
}