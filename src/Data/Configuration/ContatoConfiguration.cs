using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(x => x.UsuarioId).
                HasColumnType("INT")
                .HasColumnName("id_usuario");


            builder.HasOne(x => x.Usuario).WithMany(x => x.Contatos).HasForeignKey(x => x.UsuarioId);


        }
    }
}
