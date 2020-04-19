using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.SistemaInterno
{
    public class Movimentos
    {

        public int MovimentosId { get; private set; }

        public string Tipo { get; set; }

        public double Valor { get; set; }

        public DateTime Date { get { return DateTime.Now; } set { Date = DateTime.Now; } }

    }
}
