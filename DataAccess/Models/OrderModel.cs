using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class OrderModel
	{
			public Guid Id { get; set; }
			public string Email { get; set; }

			public List<OrderItem> Products { get; set; }

			public DateTime PurchaseDate { get; set; }

			public bool IsActive { get; set; }
	}
}
