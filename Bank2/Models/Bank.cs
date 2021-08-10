using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank2.Models
{
	public class Bank : ModelBase
	{
		public String Name { get; set; }
		public DbSet<User> Customers { get; set; }
	}
}
