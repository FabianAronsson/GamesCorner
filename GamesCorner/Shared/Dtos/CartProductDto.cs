using GamesCorner.Shared.DTOs;

namespace GamesCorner.Shared.Dtos
{
    public class CartProductDto
    {
        public string Id { get; set; }
        public ProductModelDto? Product{ get; set; }
        public int Amount { get; set; }
    }
}
