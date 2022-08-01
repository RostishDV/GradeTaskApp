using GradeTaskApp.Bank.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeTaskApp.Bank
{
	public class BankContext : DbContext
	{
        public DbSet<User> Users { get; set; }
        public DbSet<OperationType> Operations { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Account> Accounts { get; set; }
        
        public BankContext()
        {
            Database.EnsureCreated();
		}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=GradeTaskBank;Username=postgres;Password=1");
        }
    }
}
