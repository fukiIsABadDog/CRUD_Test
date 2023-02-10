using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using EF_Models.Context;

namespace CRUD_Test.Data
{
    public class MaelstromContext : EF_Models.Context
    {
        public MaelstromContext(DbContextOptions<MaelstromContext> options) : base(options) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<TestResult> TestResults => Set<TestResult>();
        public DbSet<FishType> FishTypes => Set<FishType>();
        public DbSet<Fish> Fishs => Set<Fish>();
        public DbSet<SiteUser> SiteUsers => Set<SiteUser>();
        public DbSet<SiteType> SiteType => Set<SiteType>();
        public DbSet<Site> Site => Set<Site>();

        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<AccountPayment> AccountPayments => Set<AccountPayment>();
        public DbSet<AccountStanding> AccountStandings => Set<AccountStanding>();
        public DbSet<AccountType> AccountTypes => Set<AccountType>();
        public DbSet<Payment> Payments => Set<Payment>();





        // protected override void OnConfiguring(DbContextOptionsBuilder)
        // {
        //     base.OnConfiguring(optionsBuilder)
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountPayment>()
            .HasKey(ap => new { ap.AccountID, ap.PaymentID });

            modelBuilder.Entity<SiteUser>()
            .HasKey(su => new { su.SiteID, su.UserID });
        }


    }
}
