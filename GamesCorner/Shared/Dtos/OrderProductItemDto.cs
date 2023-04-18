using GamesCorner.Shared.DTOs;

namespace GamesCorner.Shared.Dtos;

public class OrderProductItemDto
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public ProductModelDto Product { get; set; }
    public int Amount { get; set; }
}