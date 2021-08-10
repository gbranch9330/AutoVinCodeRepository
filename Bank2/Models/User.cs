using System.Collections.Generic;

namespace Bank2.Models
{
	public class User : ModelBase
	{
		public string Name { get; set; }
		public List<Account> Accounts { get; set; }
		public List<Investment> Investments { get; set; }
	}
}
