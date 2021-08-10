using Bank2.Database;
using Bank2.Enums;
using Bank2.Models;
using Bank2.Transactions;
using System.Linq;

namespace Bank2.BusinessLogic
{
	class BankWithdrawal : ProcessBase
	{
		public override string ProcessTransaction(BankContext dbContext, User user, TransactionType transactionType, decimal amount, int accountFrom, int? accountTo)
		{
			var account = dbContext.CheckingAccounts.Where(x => x.Id == accountFrom).SingleOrDefault();
			if (account == null)
			{
				return ("The account was not found");
			}

			if (transactionType == TransactionType.Withdraw)
			{
				if (account.Balance < amount)
				{
					return "Transaction failed. Not enough funds";
				}
				if (amount > 500m)
				{
					return "Transaction Failed. $500 limit exceeded";
				}
			}

			account.Balance -= amount;
			dbContext.SaveChanges();
			return "Success";
		}
	}
}
