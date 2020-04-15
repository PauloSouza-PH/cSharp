using System;
using ByteBank.Modelos.SistemaInterno;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Comparadores
{
    public class ComparadoresContaCorrente : IComparer<ContaCorrente>
    {
        public int Compare(ContaCorrente x, ContaCorrente y)
        {
            return x.CompareTo(y);
        }
    }
}
