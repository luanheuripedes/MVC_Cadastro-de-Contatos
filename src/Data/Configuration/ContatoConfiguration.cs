using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("contato");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(p => p.Nome).HasColumnType("VARCHAR(50)").HasColumnName("nome");
            builder.Property(p => p.Email).HasColumnType("VARCHAR(50)").HasColumnName("email");
            builder.Property(p => p.Celular).HasColumnType("VARCHAR(20)").HasColumnName("celular");
        }
    }
}
