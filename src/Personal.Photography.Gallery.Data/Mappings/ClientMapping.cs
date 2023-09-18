using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Personal.Photography.Gallery.Core.DomainObjects;
using Personal.Photography.Gallery.Domain.Entities;

namespace Personal.Photography.Gallery.Data.ConfigurationMappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        /// EF Core - Fluent API
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.DataNascimento)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(x => x.Cpf)
                .HasMaxLength(11)
                .IsRequired()
                .HasColumnType("varchar(11)");

            //builder.OwnsOne(c => c.Cpf, tf =>
            //{
            //    tf.Property(x => x.Numero)
            //        .IsRequired()
            //        .HasMaxLength(Cpf.CpfMaxLength)
            //        .HasColumnName("Cpf")
            //        .HasColumnType($"varchar({Cpf.CpfMaxLength})");
            //});


            builder.HasIndex(x => new { x.Nome });

            builder.ToTable("Clientes");
        }
    }
}
