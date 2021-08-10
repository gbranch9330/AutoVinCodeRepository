using Bank2.Database;
using Bank2.Enums;
using Bank2.Models;
using Bank2.Transactions;
using System.Linq;

namespace Bank2.BusinessLogic
{
	class BankDeposit : ProcessBase
	{
		public override string ProcessTransaction(BankContext dbContext, User user, TransactionType transactionType, decimal amount, int accountFrom, int? accountTo)
		{
			var account = dbContext.CheckingAccounts.Where(x => x.Id == accountFrom).SingleOrDefault();
			if (account == null)
			{
				return ("The account was not found");
			}

			if (transactionType == TransactionType.Deposit)
			{
				account.Balance += amount;
			}
			if (transactionType == TransactionType.Withdraw) { 
				if (account.Balance > amount)
				{
					account.Balance -= amount;
				}
			}

			dbContext.SaveChanges();
			return "Success";
		}
	}
}
