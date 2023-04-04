using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GamesCorner.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string Address { get; set; }
		[Required, MaxLength(4)]
        public string  PostCode{ get; set; }
		[Required]
		public string City { get; set; }
    }
}