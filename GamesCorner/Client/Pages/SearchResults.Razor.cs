using System.Net.Http.Json;
using GamesCorner.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace GamesCorner.Client.Pages
{
	partial class SearchResults : ComponentBase
	{
		[Parameter] public string SearchTerm { get; set; } = "";

		private List<ProductModelDto>? _products = new();

		protected override async Task OnParametersSetAsync()
		{
			await Search();
			await base.OnParametersSetAsync();
		}

		private async Task Search()
		{
			var client = HttpClientFactory.CreateClient("public");

			var response = await client.GetAsync($"search?name={SearchTerm}");

			if (response.IsSuccessStatusCode)
			{
				_products = await response.Content.ReadFromJsonAsync<List<ProductModelDto>>();
			}
			StateHasChanged();

			
		}
	}
}
