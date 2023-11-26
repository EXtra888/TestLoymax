using Loymax.Models;
using Microsoft.EntityFrameworkCore;
using TestLoymax.Models;

namespace Loymax.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.AmountMoney).HasColumnType("DECIMAL(30,2)");
            modelBuilder.Entity<User>().Property(u => u.DateBirth).HasColumnType("Date");
            modelBuilder.Entity<User>().Property(u => u.AmountMoney).HasDefaultValue(0);
            //modelBuilder.Entity<User>().HasIndex(u => u.Login).IsUnique();
            modelBuilder.Entity<Transaction>().Property(t => t.Amount).HasColumnType("DECIMAL(30,2)");
            modelBuilder.Entity<Transaction>().Property(t => t.DateTime).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType
                {
                    Id = 1,
                    Name = "Начисление"
                },
                new TransactionType
                {
                    Id = 2,
                    Name = "Списание"
                }
                );
        }
    }
}
