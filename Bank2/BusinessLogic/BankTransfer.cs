using Bank2.Database;
using Bank2.Enums;
using Bank2.Models;
using Bank2.Transactions;
using System.Linq;


namespace Bank2.BusinessLogic
{
	public class BankTransfer : ProcessBase
	{

		public override string ProcessTransaction(BankContext dbContext, User user, TransactionType transactionType, decimal amount, int accountFrom, int? accountTo)
		{
			var fromAccount = user.Accounts.Where(x => x.Id == accountFrom).SingleOrDefault();
			var toAccount = user.Accounts.Where(x => x.Id == accountTo).SingleOrDefault();

			if (fromAccount.Balance < amount)
			{
				return ("Process Failed. Not enough funds in account");
			}
			fromAccount.Balance -= amount;
			toAccount.Balance += amount;

			dbContext.SaveChanges();

			return ("Transaction Successful");
		}
	}
}
