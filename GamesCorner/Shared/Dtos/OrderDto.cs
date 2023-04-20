using DataAccess.Models.Enums;

namespace GamesCorner.Shared.Dtos
{
    public class OrderDto
    {
        public string Id { get; set; }
        public string CustomerEmail { get; set; }
        public List<OrderItemDto> Products { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; }
        public Status Status { get; set; }
    }
}
