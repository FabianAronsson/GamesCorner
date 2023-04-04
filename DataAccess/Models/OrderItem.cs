using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
	public class OrderItem
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public int Amount { get; set; }
        public double Price { get; set; }
	}
}
