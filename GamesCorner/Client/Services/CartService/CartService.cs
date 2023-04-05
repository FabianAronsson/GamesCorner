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

        public async Task AddToCart(OrderItemDto item, string userId)
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var Id = state.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (Id is null)
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
                var existing = cart.Products.FirstOrDefault(o => o.ProductId.Equals(item.ProductId));
                if (existing is not null)
                {
                    existing.Amount += existing.Amount;
                }
                else
                {
                    cart.Products.Add(item);
                }
            }


        }


        public async Task<List<OrderItemDto>> GetCartItems()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var Id = state.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (Id is null)
            {
                return await _localStorage.GetItemAsync<List<OrderItemDto>>("cart");
            }

            var order = await _httpClient.GetFromJsonAsync<OrderDto>("getActiveOrder");
            return order.Products;

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
