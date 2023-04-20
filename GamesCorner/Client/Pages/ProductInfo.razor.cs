using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
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
        private int i = 0;
        public List<ReviewsDto>? Reviews { get; set; } = new();
        private ReviewsDto newReview { get; set; } = new ();
        private string _authMessage;

        private bool IsSubmitted { get; set; }

        public string cartText { get; set; } = "Add to cart";

        protected override async Task OnInitializedAsync()
        {
	        var client = HttpClientFactory.CreateClient("public");
	        Reviews = await client.GetFromJsonAsync<List<ReviewsDto>>($"productReviews?productId={Guid.Parse(ProductId)}");
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
            cartText = "Added to cart";
            StateHasChanged();

            await Task.Delay(1000); // wait for 2 seconds

            cartText = "Add to cart";
            StateHasChanged();
        }
        private async Task CreateNewReview()
        {
            var client = HttpClientFactory.CreateClient("public");
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var id = state.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            IsSubmitted = true;
            StateHasChanged();
            await client.PostAsJsonAsync<ReviewsDto>("addReview", new ReviewsDto()
            {
                Content = newReview.Content,
                CreatedDateTime = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                ProductId = ProductId,
                Rating = newReview.Rating,
                UserEmail = id
            });
        }
        public static string GetStarRating(double rating)
        {
            string fullStar = "★";
            string emptyStar = "<span class='empty'>☆</span>";
            int numberOfFullStars = (int)Math.Floor(rating);
            bool hasHalfStar = (rating - numberOfFullStars) >= 0.5;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numberOfFullStars; i++)
            {
                sb.Append(fullStar);
            }
            if (hasHalfStar)
            {
                sb.Append(emptyStar);
                numberOfFullStars++;
            }
            for (int i = numberOfFullStars; i < 5; i++)
            {
                sb.Append(emptyStar);
            }

            return sb.ToString();
        }
        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }
    }
}
