using Bank2.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank2.Database
{
	public class BankContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Bank> Bank { get; set; }
		public DbSet<Account> CheckingAccounts{ get; set; }
		public DbSet<Investment> InvestmentAccounts{ get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Data Source=BankOfGeorge");
		}
	}
}
