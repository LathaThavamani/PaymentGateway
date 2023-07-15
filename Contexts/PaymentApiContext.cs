using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models;

namespace PaymentGateway.Contexts
{
    public class PaymentApiContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }

        public DbSet<Payment> Payments { get; set; }
    }
}
