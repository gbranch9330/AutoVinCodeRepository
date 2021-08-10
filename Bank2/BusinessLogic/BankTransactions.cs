using Bank2.Database;
using Bank2.Enums;
using Bank2.Models;
using Bank2.Transactions;
using System;
using System.Linq;

namespace Bank2.BusinessLogic
{
	public class BankTransactions : ProcessBase
	{
		public override string ProcessTransaction(BankContext dbContext, User user, TransactionType transactionType, decimal amount, int accountFrom, int? accountTo)
		{
			return "Testing Routines";
		}

		public void ProcessTransactions()
		{
			var dbContext = new BankContext();
			var users = dbContext.Users.ToList();
			var userId2 = users.Count;
			var userId1 = users.Count - 1;
			var user1 = users.Where(x => x.Id == userId1).FirstOrDefault();
			var user2 = users.Where(x => x.Id == userId2).FirstOrDefault();

			var bankDeposit = new BankDeposit();
			string message = bankDeposit.ProcessTransaction(dbContext, user1, TransactionType.Deposit, 100, userId1, null); // Deposit valid
			Console.WriteLine(message);

			message = bankDeposit.ProcessTransaction(dbContext, user1, TransactionType.Withdraw, 100, 1, 0); // Withdraw valid
			Console.WriteLine(message);

			message = bankDeposit.ProcessTransaction(dbContext, user1, TransactionType.Withdraw, 10000, 1, 0); // Withdraw invalid
			Console.WriteLine(message);

			var bankTransfer = new BankTransfer();
			message = bankTransfer.ProcessTransaction(dbContext, user2, TransactionType.Withdraw, 100, 1, 1); // Transfer valid
			Console.WriteLine(message);
			message = bankTransfer.ProcessTransaction(dbContext, user2, TransactionType.Withdraw, 100, 1, 2); // Transfer invalid
			Console.WriteLine(message);
		}
	}
}

