using GamesCorner.Shared.Dtos;

namespace GamesCorner.Client.Services.CartService
{
    public interface ICartService
    {
        Task AddToCart(OrderItemDto item, string userId);
        Task<List<OrderItemDto>> GetCartItems();
        Task DeleteItem(OrderItemDto item);
        Task EmptyCart(string orderId);
        Task<string> Checkout(); 
        Task<string?> GetUserId();
    }
}
