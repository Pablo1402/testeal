using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteAL.Domain.Entities;
using TesteAL.Repository.Config;

namespace TesteAL.Repository.Context
{
    public class TesteALContext : DbContext
    {
        public TesteALContext(DbContextOptions<TesteALContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfig());
        }

    }
}
