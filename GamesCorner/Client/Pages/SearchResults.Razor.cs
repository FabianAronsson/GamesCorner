using System.Net.Http.Json;
using GamesCorner.Shared.DTOs;
using Microsoft.AspNetCore.Components;

namespace GamesCorner.Client.Pages
{
	partial class SearchResults : ComponentBase
	{
		[Parameter] public string SearchTerm { get; set; } = "";

		private List<ProductModelDto>? _products = new();
		private List<ProductModelDto>? _filteredProducts = new();
		public List<string> categories = new();

      

        protected override async Task OnParametersSetAsync()
		{
            await GetAllProducts();
        }

        private async Task Search()
		{

			var client = HttpClientFactory.CreateClient("public");

			var response = await client.GetAsync($"search?name={SearchTerm}");

			if (response.IsSuccessStatusCode)
			{
				_filteredProducts = await response.Content.ReadFromJsonAsync<List<ProductModelDto>>();
			}
			StateHasChanged();

		}

		private void FilterResultsByCategory(ChangeEventArgs obj)
		{
			var category = obj.Value;

			if (category.ToString() == "All")
			{
				_filteredProducts = _products;
			}
			else
			{
				_filteredProducts = _products.Where(x => x.Category == category.ToString()).ToList();
			
			}

			StateHasChanged();
		}


		private async Task GetAllProducts()
		{
			var client = HttpClientFactory.CreateClient("public");

			var response = await client.GetAsync($"search?name={SearchTerm}");

			if (response.IsSuccessStatusCode)
			{
				_products = await response.Content.ReadFromJsonAsync<List<ProductModelDto>>();
			}

			categories = _products.Select(x => x.Category).Distinct().ToList();
			StateHasChanged();
		}
	}
}
