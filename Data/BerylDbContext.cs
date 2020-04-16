using System;
using Microsoft.EntityFrameworkCore;
using Beryl.Models;
using Beryl.Data.Configuration;

namespace Beryl.Data
{

    public abstract class BerylDbContext : DbContext
    {
        public BerylDbContext(DbContextOptions<BerylDbContext> options) : base(options) { }
        public BerylDbContext(DbContextOptions<BerylSqliteContext> options) : base(options) { }
        public BerylDbContext(DbContextOptions<BerylInMemoryContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.ApplyConfiguration(new RedirectConfig());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Redirect> Redirects { get; set; }
    }
}
