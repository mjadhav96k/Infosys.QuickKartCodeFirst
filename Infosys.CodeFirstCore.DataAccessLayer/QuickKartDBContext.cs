using Infosys.CodeFirstCore.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infosys.CodeFirstCore.DataAccessLayer
{
    public class QuickKartDBContext :DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder != null)
            {
                optionsBuilder.UseSqlServer("data source=DESKTOP-217J50E\\SQLEXPRESS;Initial Catalog=QuickKartCodeFirst;Integrated Security=true;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                        .HasAlternateKey("CategoryName")
                        .HasName("uq_CategoryName");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasAlternateKey(e => e.ProductName)
                      .HasName("uq_ProductName");
                //entity.Property(e => e.ProductId)
                //      .HasColumnType("char(4)");
                entity.HasOne(c => c.Category)
                      .WithMany(p => p.Products)
                      .HasForeignKey(c => c.CategoryId)
                      .HasConstraintName("fk_CategoryId");
            });
        }

    }
}
