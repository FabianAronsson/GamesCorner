using System.Net.Http.Json;
using GamesCorner.Shared.Dtos;
using GamesCorner.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace GamesCorner.Client.Pages
{
    partial class ProductInfo : ComponentBase
    {
        [Parameter] public string ProductId { get; set; }
        public ProductModelDto Product { get; set; } = new();
        public List<ReviewsDto> DisplayedReviews { get; set; } = new();
        public List<ReviewsDto> ActualReviews { get; set; } = new();
        public ReviewsDto newReview { get; set; } = new();
        private int ProductScore = 0;

        private bool IsSubmitted { get; set; }
        public string cartText { get; set; } = "Add to cart";


        private int selectedVal = 0;

        private int? activeVal;
        private void HandleHoveredValueChanged(int? val) => activeVal = val;

        private int GetProductScore()
        {
            if (ActualReviews.Count != 0)
            {
                ProductScore = ActualReviews.Sum(x => x.Rating) / ActualReviews.Count;
            }
            else
            {
                ProductScore = 0;
            }
            return ProductScore;
        }
        private string LabelText => (activeVal ?? selectedVal) switch
        {
            1 => "Very bad",
            2 => "Bad",
            3 => "Okay",
            4 => "Good",
            5 => "Awesome!",
            _ => "Rate the game!"
        };


        protected override async Task OnInitializedAsync()
        {
            await GetReviews();
            GetProductScore();
        }

        private async Task GetReviews()
        {
            var client = HttpClientFactory.CreateClient("public");
            ActualReviews = await client.GetFromJsonAsync<List<ReviewsDto>>($"productReviews?productId={Guid.Parse(ProductId)}");
            DisplayedReviews = new List<ReviewsDto>(ActualReviews.Take(3));
            ProductScore = GetProductScore();
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
            MessageService.UpdateCartAmount(await CartService.GetCartAmount());
			await Task.Delay(1000); // wait for 2 seconds

            cartText = "Add to cart";
            StateHasChanged();

            
        }
       
		private async Task CreateNewReview()
        {
            var client = HttpClientFactory.CreateClient("public");
            var state = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var id = state.User.Claims.FirstOrDefault(c => c.Type == "name")?.Value ?? "anonymous";

            await client.PostAsJsonAsync("addReview", new ReviewsDto()
            {
                Content = newReview.Content,
                CreatedDateTime = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                ProductId = ProductId,
                Rating = selectedVal,
                UserEmail = id
            });

            newReview = new();
            selectedVal = 0;
            await GetReviews();
            StateHasChanged();
        }

        protected override async Task OnParametersSetAsync()
        {
            await GetProduct();
        }

        private bool shouldCollapse = true;
        public string CollapseReviewMenu => shouldCollapse ? "collapse" : null;
        private void ChangeVisibility()
        {
            shouldCollapse = !shouldCollapse;
        }

        private void LoadReviews()
        {
            DisplayedReviews.AddRange(ActualReviews.Skip(DisplayedReviews.Count).Take(3));
            StateHasChanged();
        }
    }
}
