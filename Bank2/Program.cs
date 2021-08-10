using Bank2.Database;
using Bank2.BusinessLogic;
using Bank2.Enums;
using Bank2.Models;
using Bank2.Transactions;
using System;

namespace Bank2
{
	class Program
	{
		private static BankContext _bankContext = new BankContext();
		static void Main(string[] args)
		{
			_bankContext.Database.EnsureCreated();
			var populate = new PopulateDatabase();
			populate.PopulateDatabaseRecords();

			var result = new BankTransactions();
			result.ProcessTransactions();
			
			Console.WriteLine("Finished");
		}
	}
}
