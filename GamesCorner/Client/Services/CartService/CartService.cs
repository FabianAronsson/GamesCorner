using System.Net.Http.Json;
using System.Security.Claims;
using Blazored.LocalStorage;
using GamesCorner.Shared.Dtos;
using Microsoft.AspNetCore.Components.Authorization;


namespace GamesCorner.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public CartService(ILocalStorageService localStorage, IHttpClientFactory httpClientFactory, HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _localStorage = localStorage;
            _httpClientFactory = httpClientFactory;
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string?> GetUserId()
        {
           
                var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
                var id = state.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                return id?.Value;
        }

        public async Task AddToCart(OrderItemDto item, string userId)
        {
            if (await GetUserId() is null)
            {
                var cart = await _localStorage.GetItemAsync<List<OrderItemDto>>("cart") ?? new List<OrderItemDto>();
                var existing = cart.FirstOrDefault(i => i.Id.Equals(item.Id));
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
            else
            {
                var result = await _httpClient.PostAsJsonAsync("addToCart", item);
                await result.Content.ReadFromJsonAsync<OrderItemDto>();
            }
        }


        public async Task<List<OrderItemDto>> GetCartItems()
        {
            if (await GetUserId() is null)
            {
                return await _localStorage.GetItemAsync<List<OrderItemDto>>("cart") ?? new List<OrderItemDto>();
            }

            var order = await _httpClient.GetFromJsonAsync<OrderDto>("getActiveOrder");
            return order.Products;
        }

        public async Task DeleteItem(OrderItemDto item)
        {
            if (GetUserId() is null)
            {
                var cart = await _localStorage.GetItemAsync<List<OrderItemDto>>("cart");
                cart.Remove(item);
                await _localStorage.SetItemAsync("cart", cart);
            }
            else
            {
                 await _httpClient.DeleteAsync($"deleteItemFromCart/{item.Id}");
            }
            
        }

        public async Task EmptyCart(string orderId)
        {
            if (await GetUserId() is null)
            {
                var cart = await _localStorage.GetItemAsync<List<OrderItemDto>>("cart");
                cart.Clear();
                await _localStorage.SetItemAsync("cart", cart);
            }
            else
            {
                await _httpClient.DeleteAsync($"emptyCart/{orderId}");
            }
        }

        public async Task<string> Checkout()
        {
            var cartItems = await GetCartItems();
            var httpClient = _httpClientFactory.CreateClient("public");
            var result = await httpClient.PostAsJsonAsync("checkout", cartItems);
            var url = await result.Content.ReadAsStringAsync();
            return url;
        }
    }
}
