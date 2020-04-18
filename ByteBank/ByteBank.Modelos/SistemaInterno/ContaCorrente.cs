using ByteBank.Modelos.dbSys;
using ByteBank.Modelos.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.SistemaInterno
{
    /// <summary>
    /// Define uma Conta Corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente : IComparable
    {
        public static int TotalDeContasCriadas { get; private set; }
        public static int TaxaOperacao { get ; private set; }
        public Cliente Titular { get; private set; }
        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }
        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo;
        
        public double Saldo { get; private set; }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia"> Representa o valor da propriedade <see cref="Agencia"/> e deve possuir um valor maior que zero. </param>
        /// <param name="numero"> Representa o valor da propriedade <see cref="Numero"/> e deve possuir um valor maior que zero. </param>
        /// <param name="cliente"> Representa o valor da propriedade <see cref="Cliente"/> e não pode ser nulo. </param>
        public ContaCorrente(int agencia, int numero, Cliente cliente)
        {
            if (agencia <= 0)
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
           
            if (numero <= 0)
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));

            if (cliente == null)
                throw new ArgumentNullException("O argumento fornecido esta nulo", nameof(cliente));
            
            Agencia = agencia;
            Numero = numero;
            Titular = cliente;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"/>.
        /// </summary>
        /// <exception cref="ArgumentException"> Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>. </exception>
        /// <exception cref="SaldoInsuficienteException"> Exceção lançada quando o valor de <paramref name="valor"/> é maior que o valor da propriedade <see cref="Saldo"/>. </exception>
        /// <param name="valor"> Representa o valor do saque, deve ser maior que 0 e menor que o <see cref="Saldo"/>. </param>
        public void Sacar(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            
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
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            
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

        public override string ToString()
        {
            return $"Agencia:{Agencia} \tConta: {Numero}";
        }

        public int CompareTo(object obj)
        {
            /*-1=Precedencia
               0=Equivalente
               1=Proximo*/
            var outraConta = obj as ContaCorrente;

            if (Agencia < outraConta.Agencia || outraConta == null)
                return -1;

            if (Agencia == outraConta.Agencia)
                return 0;

            return 1;
        }
    }

}
