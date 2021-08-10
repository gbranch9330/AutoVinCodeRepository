using Bank2.Enums;
using Bank2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bank2.Database
{
	public class PopulateDatabase
	{
		public BankContext _dbContext;

		public PopulateDatabase()
		{
			_dbContext = new BankContext();
		}

		public void PopulateDatabaseRecords()
		{
			AddRecords();
		}

		public void AddRecords()
		{
			if (_dbContext.Users.ToList() != null)
			{
				return;
			}

			var bank = new Bank
			{
				Name = "MyBank"
			};
			_dbContext.Add<Bank>(bank);
			_dbContext.SaveChanges();

			var user1 = new User
			{
				Name = "Fred Sanford"
			};

			var user2 = new User
			{
				Name = "Sam Snead"
			};
			_dbContext.Add(user1);
			_dbContext.Add(user2);
			_dbContext.SaveChanges();

			var account1 = new Account
			{
				Balance = 5000m,
				User = _dbContext.Users.Where(x => x.Id == user1.Id).FirstOrDefault()
			};

			var account2 = new Account
			{
				Balance = 50m,
				User = _dbContext.Users.Where(x => x.Id == user1.Id).FirstOrDefault()
			};

			var account3 = new Account
			{
				Balance = 5000m,
				User = _dbContext.Users.Where(x => x.Id == user1.Id).FirstOrDefault()
			};

			var account4 = new Account
			{
				Balance = 499m,
				User = _dbContext.Users.Where(x => x.Id == user2.Id).FirstOrDefault()
			};

			var account5 = new Account
			{
				Balance = 5000m,
				User = _dbContext.Users.Where(x => x.Id == user2.Id).FirstOrDefault()
			};

			var accounts = new List<Account> { account1, account2, account3 };
			var accounts2 = new List<Account> { account4, account5 };
			user1.Accounts = accounts;
			user2.Accounts = accounts2;

			_dbContext.Add(account1);
			_dbContext.Add(account2);
			_dbContext.Add(account3);
			_dbContext.Add(account4);
			_dbContext.Add(account5);
			_dbContext.SaveChanges();
		}
	}
}
