using Microsoft.EntityFrameworkCore;
using RallyDakar.Dominio.Entidades;

namespace RallyDakar.Dominio.DbContexto
{
    public class RallyDbContext:DbContext
    {
        //Configurando os DbSets
        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Telemetria> Telemetrias { get; set; }

        public RallyDbContext(DbContextOptions<RallyDbContext> options):base(options)
        {

        }
    }
}
