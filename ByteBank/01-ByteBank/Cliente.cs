using System;
using Util;

namespace ByteBank
{
    class Cliente
    {
        public int id;
        public string nome;
        protected string cgc;
        protected DateTime dtNascimento;
        protected DateTime dtRegistro;
        protected int idade;


        public Cliente(string nome, string cgc, DateTime dtNascimento)
        {
            this.id++;/*GetMax - inicialmente será usado somente 0-1*/;
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.cgc = cgc;
            this.dtNascimento = dtNascimento;
            this.dtRegistro = DateTime.Now.ToLocalTime();
            this.idade = new Utilidades().GetIdade(dtNascimento);
        }

    }
}