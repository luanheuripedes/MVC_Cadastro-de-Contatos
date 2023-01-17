
using ControleDeContatos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class BancoContext:DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options):base(options)
        {
        }

        public DbSet<ContatoEntitie> Contatos { get; set; }

    }
}
