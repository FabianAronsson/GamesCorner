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
                var existing = cart?.FirstOrDefault(i => i.ProductId.Equals(item.ProductId));
                if (existing != null)
                {
                    existing.Amount++;
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

        public async Task<int> GetCartAmount()
        {
            var totalAmount = 0;
	        var result = await GetCartItems();
	        foreach (var product in result)
	        {
		        totalAmount += product.Amount;
	        }
	        return totalAmount;
        }

        public async Task DeleteItem(OrderItemDto item)
        {
            if (await GetUserId() == null)
            {
                var cart = await _localStorage.GetItemAsync<List<OrderItemDto>>("cart");
                if (item.Amount - 1 <= 0)
                {
                    var res = cart.FirstOrDefault(o => o.ProductId.Equals(item.ProductId));
                    cart.Remove(res);
                }
                else
                {
                    var product = cart.FirstOrDefault(p => p.ProductId.Equals(item.ProductId));
                    product.Amount--;
                }
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
        public async Task EmptyGuestCart()
        {
            var cart = await _localStorage.GetItemAsync<List<OrderItemDto>>("cart");
			cart.Clear();
			await _localStorage.SetItemAsync("cart", cart);
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
