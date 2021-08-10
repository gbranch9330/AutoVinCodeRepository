using Bank2.Database;
using Bank2.Enums;
using Bank2.Models;
using System;

namespace Bank2.Transactions
{
	public abstract class ProcessBase
	{
		BankContext _dbContext = new BankContext();

		public abstract string ProcessTransaction(BankContext _dbContext, User user, TransactionType transactionType, decimal amount, int accountFrom, int? accountTo);

		public User ValidateUser(string id)
		{
			int result;
			bool success = Int32.TryParse(id, out result);
			if (!success)
			{
				Console.WriteLine("Invalid user Id.");
				return null;
			}

			var user = _dbContext.Find<User>(result);
			if (user == null)
			{
				return user;
			}

			return user;
		}
	}
}
