namespace DataAccess.Models
{
	public class OrderItem
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public int Amount { get; set; }
    }
}
