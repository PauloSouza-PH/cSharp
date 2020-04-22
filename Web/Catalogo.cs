using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Catalogo : ICatalogo
    {
        public List<Livro> GetLivros()
        {
            var livros = new List<Livro>();
            livros.Add(new Livro("001", "Desconhecido", 10.29m));
            livros.Add(new Livro("002", "Qualquer 1", 12.29m));

            return livros;
        }
    }
}
