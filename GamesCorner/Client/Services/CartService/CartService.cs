using System.Runtime.CompilerServices;
using Blazored.LocalStorage;
using GamesCorner.Shared.Dtos;


namespace GamesCorner.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;

        public CartService(ILocalStorageService localStorage, HttpClient httpClient)
        {
            _localStorage = localStorage;   
            _httpClient = httpClient;
        }

        public async Task AddToCart(OrderItemDto item)
        {
            var cart = await _localStorage.GetItemAsync<List<OrderItemDto>>("cart") ?? new List<OrderItemDto>();
            var existing = cart.FirstOrDefault(i=>i.Id.Equals(item.Id));
            if (existing is not null)
            {
                existing.Amount += existing.Amount;
            }
            else
            {
                cart.Add(item);
            }
            await _localStorage.SetItemAsync("cart", cart);
        }


        public Task<List<OrderItemDto>> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public Task DeleteItem(OrderItemDto item)
        {
            throw new NotImplementedException();
        }

        public Task EmptyCart()
        {
            throw new NotImplementedException();
        }

        public Task<string> Checkout()
        {
            throw new NotImplementedException();
        }
    }
}
