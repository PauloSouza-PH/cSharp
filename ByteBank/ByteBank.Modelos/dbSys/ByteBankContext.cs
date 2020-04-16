using ByteBank.Modelos.SistemaInterno;
using Microsoft.EntityFrameworkCore;

namespace ByteBank.Modelos.dbSys
{   
    /// <summary>
    /// Classe responsável por persistir os dados na base
    /// </summary>
    public class ByteBankContext : DbContext
    {   
        /// <summary>
        /// Contexto public para persistencia da conta corrente
        /// </summary>
        public DbSet<ContaCorrente> ContaCorrente { get; set; }

        /// <summary>
        /// Metodo padrão para persistencia dos dados
        /// </summary>
        /// <param name="optionsBuilder"> Variavel do tipo <see cref="DbContextOptionsBuilder"/> responsável pela configuração da persistencia </param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder ) {

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ByteBank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}
