namespace GamesCorner.Shared.Dtos;

public class OrderWithProductsDto
{
    public string Id { get; set; }
    public string CustomerEmail { get; set; }
    public List<OrderProductItemDto> Products { get; set; }
    public DateTime PurchaseDate { get; set; }
    public bool IsActive { get; set; }
}