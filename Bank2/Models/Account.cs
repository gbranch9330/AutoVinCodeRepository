namespace Bank2.Models
{
	public class Account : ModelBase
	{
		public int UserId { get; set; }
		public User User { get; set; }
		public decimal Balance { get; set; }
	}
}
