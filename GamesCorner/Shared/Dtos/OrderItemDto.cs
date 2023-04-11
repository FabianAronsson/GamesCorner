using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCorner.Shared.Dtos
{
    public class OrderItemDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public int Amount { get; set; }
    }
}
