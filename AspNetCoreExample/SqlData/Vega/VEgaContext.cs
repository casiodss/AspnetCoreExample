using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspNetCoreExample.SqlData.Vega
{
    public partial class VEgaContext : DbContext
    {
        public VEgaContext(DbContextOptions<VEgaContext> options) : base(options) { }

        public virtual DbSet<Makes> Makes { get; set; }
        public virtual DbSet<Models> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=SHREK\MYSQLSERVER;Database=VEga;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models>(entity =>
            {
                entity.HasIndex(e => e.MakeId);

                entity.HasOne(d => d.Make)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.MakeId);
            });
        }
    }
}
