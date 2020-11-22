using System.Linq;
using easyharbour.Model;
using easyharbour.Models;
using Microsoft.EntityFrameworkCore;

namespace VLI.SIOP.Operacao.Dados
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> options)
            : base(options)
        {
        }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }

            base.OnModelCreating(modelBuilder);

           // modelBuilder.BuildIndexesFromAnnotations();
        }


        public DbSet<Navio> Navios { get; set; }
        public DbSet<TabuaMare> TabuaMares { get; set; }
        public DbSet<Atracacao> Atracacao { get; set; }
        public DbSet<BercoGrao> BercosGraos { get; set; }
        public DbSet<Viagem> Viagens { get; set; }

    }
}
