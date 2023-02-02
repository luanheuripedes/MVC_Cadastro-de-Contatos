
using Data.Configuration;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Context
{
    public class BancoContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BancoContext()
        {
        }

        public BancoContext(DbContextOptions<BancoContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<Contato> Contatos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .EnableSensitiveDataLogging()
            .UseMySql(_configuration.GetConnectionString("ContatoConnectionString"), ServerVersion.AutoDetect(_configuration.GetConnectionString("ContatoConnectionString")),
                            p => p.EnableRetryOnFailure(maxRetryCount: 2,
                                maxRetryDelay: TimeSpan.FromSeconds(2),
                                errorNumbersToAdd: null));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
