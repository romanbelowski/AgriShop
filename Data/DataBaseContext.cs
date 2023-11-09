using Microsoft.EntityFrameworkCore;
using WSLab.Models.Domain;

namespace WSLab.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)"); // Here, "18" is the precision and "2" is the scale

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Product> Products { get; set; }
    }
}
