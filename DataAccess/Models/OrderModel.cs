using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models.Enums;

namespace DataAccess.Models
{
	public class OrderModel
	{
			public Guid Id { get; set; }
			public string CustomerEmail { get; set; }
            public virtual ICollection<OrderItem> Products { get; set; }
            public DateTime PurchaseDate { get; set; }
            public bool IsActive { get; set; }
            public OrderStatus OrderStatus { get; set; }
	}
}
