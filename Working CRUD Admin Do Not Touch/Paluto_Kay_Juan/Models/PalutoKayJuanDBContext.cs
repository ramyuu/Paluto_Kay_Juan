using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Paluto_Kay_Juan.Models
{
    public partial class PalutoKayJuanDBContext : DbContext
    {
        public PalutoKayJuanDBContext()
        {

        }

        public PalutoKayJuanDBContext(DbContextOptions<PalutoKayJuanDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PkjmenuDb> PkjmenuDbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=desktop-0of9s1e\\sqlexpress; Database=PalutoKayJuanDB; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PkjmenuDb>(entity =>
            {
                entity.ToTable("PKJMenuDB");

                entity.Property(e => e.FoodCategory).HasMaxLength(50);

                entity.Property(e => e.FoodName).HasMaxLength(50);

                entity.Property(e => e.ImageLocation).HasMaxLength(100);

                entity.Property(e => e.PricePerOrder).HasColumnType("decimal(20, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
