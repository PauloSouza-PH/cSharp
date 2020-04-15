using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Interfaces
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);
    }
}
