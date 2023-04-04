using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace GamesCorner.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Adress { get; set; }
		public string PostNumber { get; set; }
		public string City { get; set; }
	}
}