namespace Bank2.Models
{
	public class Investment : ModelBase
	{
		public decimal Balance { get; set; }
		public User User { get; set; }
		public int UserId { get; set; } 
	}
}
