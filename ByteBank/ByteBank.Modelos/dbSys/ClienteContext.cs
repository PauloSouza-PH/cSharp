using ByteBank.Modelos.SistemaInterno;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.Modelos.dbSys
{   
    /// <summary>
    /// Classe responsável por persistir os dados na base
    /// </summary>
    public class ClienteContext : DbContext
    {   
        /// <summary>
        /// Contexto public para persistencia da conta corrente
        /// </summary>
        public DbSet<Cliente> Cliente { get; set; }

        /// <summary>
        /// Metodo padrão para persistencia dos dados
        /// </summary>
        /// <param name="optionsBuilder"> Variavel do tipo <see cref="DbContextOptionsBuilder"/> responsável pela configuração da persistencia </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder ) {

            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = ByteBank; Trusted_Connection = true;");
            
        }

    }
}
