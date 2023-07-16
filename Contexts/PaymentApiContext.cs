using Microsoft.EntityFrameworkCore;
using PaymentGateway.Models;

namespace PaymentGateway.Contexts
{
    // Creating context for Entity Framework in-memory payment database
    // Store and persist data during application build
    public class PaymentApiContext : DbContext
    {
        // Configuring & setting payment in-memory DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "PaymentDB");
        }

        public DbSet<Payment> Payments { get; set; }
    }
}
