using ArchiLog.Models;
using Microsoft.EntityFrameworkCore;

namespace ArchiLog.Data
{
    public class ArchiLogDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=archilog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Car> Cars { get; set; }
    }
}
