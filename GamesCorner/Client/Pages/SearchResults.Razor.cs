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
		public List<int> ages = new();
		public List<double> prices = new() { 100, 200, 300, 400, 500, 600, 700, 800, 900 };
		public int selectedAge = 100;
		public double selectedPrice = int.MaxValue;
		public string selectedCategory { get; set; } = "";

		protected override async Task OnParametersSetAsync()
		{
            await GetAllProducts();
        }


		private void FilterResultsByAge(ChangeEventArgs obj)
		{
			var filter = obj.Value;

			int.TryParse(filter.ToString(), out selectedAge);


			if (filter.ToString() == "Age...")
			{
				selectedAge = 100;
			}

			_filteredProducts = FilteredList();

			StateHasChanged();
		}

		private void FilterResultsByPrice(ChangeEventArgs obj)
		{
			var filter = obj.Value;

			double.TryParse(filter.ToString(), out selectedPrice);

			if (filter.ToString() == "Price...")
			{
				selectedPrice = int.MaxValue;
			}

			_filteredProducts = FilteredList();

			StateHasChanged();
		}

		private void FilterResultsByCategory(ChangeEventArgs obj)
		{
			var filter = obj.Value;

			selectedCategory = filter.ToString();

			if (selectedCategory == "Category...")
			{
				selectedCategory = "";
			}

			_filteredProducts = FilteredList();

			StateHasChanged();
		}

		private void OrderBy(ChangeEventArgs obj)
		{
			var value = obj.Value;

			int.TryParse(value.ToString(), out int switchValue);

			switch (switchValue)
			{
				case 1:
					_filteredProducts = FilteredList().OrderBy(x => x.Price).ToList();
					break;
				case 2:
					_filteredProducts = FilteredList().OrderByDescending(x => x.Price).ToList();
					break;
				case 3:
					_filteredProducts = FilteredList().OrderBy(x => x.Name).ToList();
					break;
				default:
					_filteredProducts = FilteredList();
					break;
			}
			StateHasChanged();
		}

		public List<ProductModelDto> FilteredList()
		{
			var filteredList = _filteredProducts = _products.Where(p => p.Category.Contains(selectedCategory) && p.Price <= selectedPrice && p.AgeRestriction <= selectedAge).ToList();

			return filteredList;
		}

		private async Task GetAllProducts()
		{
			var client = HttpClientFactory.CreateClient("public");
            var temp = await AuthenticationStateProvider.GetAuthenticationStateAsync();

			var response = await client.GetAsync($"search?name={SearchTerm}");

			if (response.IsSuccessStatusCode)
			{
				_products = await response.Content.ReadFromJsonAsync<List<ProductModelDto>>();
			}

			categories = _products.Select(x => x.Category.Split(" ").First()).Distinct().ToList();
			ages = _products.Select(x => x.AgeRestriction).Distinct().ToList();
			_filteredProducts = _products;
			StateHasChanged();
		}
	}
}
