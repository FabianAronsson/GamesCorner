namespace DataAccess.Models;

public class UserEventModel
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public string Phone { get; set; }
	public string EventId { get; set; }
}