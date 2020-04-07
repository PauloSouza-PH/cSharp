using System;
using Util;

namespace ByteBank
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cgc { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataRegistro { get; set; }
        public int Idade
        {
            get
            {
                return new Utilidades().GetIdade(DataNascimento);
            }
            set
            {
            }
        }

        public Cliente(string nome, string cgc, DateTime dtNascimento)
        {
            Id++;/*GetMax - inicialmente será usado somente 0-1*/;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Cgc = cgc ?? throw new ArgumentNullException(nameof(cgc));
            DataNascimento = dtNascimento;
            DataRegistro = DateTime.Now.ToLocalTime();
        }

    }
}