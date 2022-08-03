using GradeTaskApp.Bank.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GradeTaskApp.Bank
{
	public class BankContext : DbContext
	{
        public DbSet<User> Users { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Account> Accounts { get; set; }
        
        public BankContext()
        {
            Database.EnsureCreated();
		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
			optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
				.EnableSensitiveDataLogging();
			optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=GradeTaskBank;Username=postgres;Password=1");
        }
    }
}
