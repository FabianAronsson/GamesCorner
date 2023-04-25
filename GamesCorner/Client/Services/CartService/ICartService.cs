using GamesCorner.Shared.Dtos;

namespace GamesCorner.Client.Services.CartService
{
    public interface ICartService
    {
        Task AddToCart(OrderItemDto item, string userId);
        Task<List<OrderItemDto>> GetCartItems();
        Task<int> GetCartAmount();
        Task DeleteItem(OrderItemDto item);
        Task EmptyCart(string orderId);
        Task EmptyGuestCart();
		Task<string> Checkout();
        Task<string?> GetUserId();
    }
}
