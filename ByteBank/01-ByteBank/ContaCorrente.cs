using System;

class ContaCorrente
{
    public Cliente cliente;
    public int Agencia;
    public int Conta;
    public double saldo;

    public ContaCorrente(Cliente cliente, int agencia, int conta)
    {
        this.cliente = cliente;
        Agencia = agencia;
        Conta = conta;
    }

        

}