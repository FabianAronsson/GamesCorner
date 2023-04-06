using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Blazored.LocalStorage;
using GamesCorner.Shared.Dtos;
using Microsoft.AspNetCore.Components.Authorization;


namespace GamesCorner.Client.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public CartService(ILocalStorageService localStorage, HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider)
        {
            _localStorage = localStorage;   
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string> GetUserId()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var id = state.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return id;
        }

        public async Task AddToCart(OrderItemDto item, string userId)
        {
            
            if (GetUserId() is null)
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
                var cart = await _httpClient.GetFromJsonAsync<OrderDto>("getActiveOrder");
                var existing = cart?.Products.FirstOrDefault(o => o.ProductId.Equals(item.ProductId));
                if (existing is not null)
                {
                    existing.Amount += existing.Amount;
                }
                else
                { 
                    var result = await _httpClient.PostAsJsonAsync("addToCart", item);
                    await result.Content.ReadFromJsonAsync<OrderItemDto>();
                }
            }
        }


        public async Task<List<OrderItemDto>> GetCartItems()
        {
            if (GetUserId() is null)
            {
                return await _localStorage.GetItemAsync<List<OrderItemDto>>("cart");
            }

            var order = await _httpClient.GetFromJsonAsync<OrderDto>("getActiveOrder");
            return order.Products;
            
        }

        public async Task DeleteItem(OrderItemDto item)
        {
            if (GetUserId() is null)
            {
                var cart = await _localStorage.GetItemAsync<List<OrderItemDto>>("cart") ?? new List<OrderItemDto>();
                cart.Remove(item);

            }
            else
            {
                 await _httpClient.DeleteAsync($"deleteItemFromCart/{item.Id}");
            }
            
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
