using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web
{
    public class Relatorio : IRelatorio
    {
        public Relatorio(ICatalogo catalogo)
        {
            this.catalogo = catalogo;
        }

        public async Task Imprimir(HttpContext context)
        {
            foreach (Livro item in catalogo.GetLivros())
            {
                await context.Response.WriteAsync(item.ToString());
            }
        }

        public ICatalogo catalogo { get; }
    }
}
