using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCorner.Shared.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItemDto>? Products { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; }
    }
}
