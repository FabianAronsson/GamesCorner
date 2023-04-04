using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace GamesCorner.Server.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		public string Address { get; set; }
		[MaxLength(4)]
        public string  PostCode{ get; set; }
		[Required]
		public string City { get; set; }
    }
}