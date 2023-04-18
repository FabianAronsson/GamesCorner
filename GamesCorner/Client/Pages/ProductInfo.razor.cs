using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Blazored.LocalStorage;
using GamesCorner.Client.Services.CartService;
using GamesCorner.Shared.Dtos;
using GamesCorner.Shared.DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace GamesCorner.Client.Pages
{
    partial class ProductInfo : ComponentBase
    {
        [Parameter] public string ProductId { get; set; }

        public ProductModelDto Product { get; set; } = new();

        public List<string> _fakeReviews { get; set; } = new() { "This game is an absolute blast to play! The graphics are stunning, the gameplay is addictive, and the storyline is compelling. I love the way the game encourages exploration and experimentation, and the level design is top-notch. Overall, this is one of the best games I've played in years.", "While this game has some interesting ideas and mechanics, it ultimately falls short of its potential. The controls can be frustrating at times, and the pacing feels uneven. The story is also a bit convoluted, and I found it hard to stay engaged. Overall, this game is worth checking out if you're a fan of the genre, but it's not a must-play", "This game is a masterpiece! The world-building is incredible, the characters are well-developed, and the voice acting is top-notch. The gameplay is challenging but rewarding, and there are so many different paths to take that you'll never get bored. If you're a fan of immersive, story-driven games, you absolutely need to check this one out", "I was really excited to play this game, but unfortunately, it didn't live up to my expectations. The graphics are lackluster, and the controls feel clunky and unresponsive. The storyline is also underwhelming, and I found myself struggling to stay interested. Overall, I wouldn't recommend this game unless you're a die-hard fan of the genre.\"", "\"This game is an absolute gem! The art style is gorgeous, the music is beautiful, and the gameplay is innovative and addictive. I love the way the game challenges you to think outside the box and come up with creative solutions to puzzles. Overall, this is one of the best indie games I've played in a long time, and I highly recommend it" };

        public AuthenticationStateProvider _authenticationStateProvider { get; set; }
        private string _authMessage;

        private IEnumerable<Claim> _claims = Enumerable.Empty<Claim>();

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private async Task GetProduct()
        {
            var GuidFromString = new Guid(ProductId);
            var client = HttpClientFactory.CreateClient("public");

            var response = await client.GetAsync($"getProduct?id={GuidFromString}");

            if (response.IsSuccessStatusCode)
            {
                Product = await response.Content.ReadFromJsonAsync<ProductModelDto>();

            }
            StateHasChanged();
        }
        private async Task AddProductToCart()
        {
            await CartService.AddToCart(new OrderItemDto()
            {
                Id = Guid.NewGuid().ToString(),
                ProductId = Product.Id,
                Amount = 1
            }, await CartService.GetUserId());
        }
    }


}
