using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{   
    /// <summary>
    /// Define uma conta corrente do banco ByteBank
    /// </summary>
    public class ContaCorrente
    {
        /// <summary>
        /// Taxa de operação privada, serve para base de calculo
        /// </summary>
        private static int TaxaOperacao;

        /// <summary>
        /// Incrementa a quantidade de contas
        /// </summary>
        public static int TotalDeContasCriadas { get; private set; }

        /// <summary>
        /// Define o objeto cliente da conta
        /// </summary>
        public Cliente Titular { get; set; }

        /// <summary>
        /// Conta quantos saques são realizados
        /// </summary>
        public int ContadorSaquesNaoPermitidos { get; private set; }
        /// <summary>
        /// Conta transferencias não permitidas
        /// </summary>
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        /// <summary>
        /// Getter Numero da conta
        /// </summary>
        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Construtor da conta corrente, incrementa o <see cref="TotalDeContasCriadas"/>
        /// e calcula a <see cref="TaxaOperacao"/>
        /// </summary>
        /// <exception cref="ArgumentException" Exceção lançada falta informar o numero da agencia ou conta orretamente
        /// <param name="agencia"> Representa o valor da propriedade <see cref="Agencia"/> e precisa ser maior que zero </param>
        /// <param name="numero"> Representa o valor da propriedade <see cref="Numero"/>e precisa ser maior que zero </param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }
    }

}
