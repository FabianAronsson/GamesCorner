using Microsoft.AspNetCore.Identity;

namespace DataAccess.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? Address { get; set; } = string.Empty;

		public string? PostCode { get; set; } = string.Empty;
		
		public string? City { get; set; } = string.Empty;
	}
}