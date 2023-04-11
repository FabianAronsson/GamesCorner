using System.Net.Http.Json;
using GamesCorner.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace GamesCorner.Client.Pages
{
	partial class ProductInfo : ComponentBase
	{
		[Parameter] public string ProductId { get; set ; }

		public ProductModelDto Product { get; set; } = new();

		protected override async Task OnParametersSetAsync()
		{
			await GetProduct();
			await base.OnParametersSetAsync();
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
	}
}
