using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class CRMDatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\projectmodels;Database=CustomerRelationshipManagementDatabase;Trusted_Connection = true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CommunicationHistory> CommunicationHistories { get; set; }
        public DbSet<CommunicationResult> CommunicationResults { get; set; }
        public DbSet<CommunicationType> CommunicationTypes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OfferType> OfferTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleStatus> SaleStatus { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
