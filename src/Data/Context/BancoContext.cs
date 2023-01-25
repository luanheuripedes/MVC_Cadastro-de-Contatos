
using Data.Entities;
using Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Data.Context
{
    public class BancoContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public BancoContext()
        {
        }

        public BancoContext(DbContextOptions<BancoContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public virtual DbSet<UsuarioEntitie> Contatos { get; set; }
        public virtual DbSet<UsuarioEntitie> Usuarios { get; set; }


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
