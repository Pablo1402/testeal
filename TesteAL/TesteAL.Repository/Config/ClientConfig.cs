using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TesteAL.Domain.Entities;

namespace TesteAL.Repository.Config
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.ToTable("CLIENT");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Id).IsRequired().HasColumnName("id");
            entity.Property(x => x.Name).IsRequired().HasColumnName("name").HasColumnType("varchar(100)");
            entity.Property(x => x.Age).IsRequired().HasColumnName("age");

        }
    }
}
