using Microsoft.EntityFrameworkCore;
using WSLab.Models.Domain;

namespace WSLab.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
