using DataAccess.Models;
using DataAccess.UnitOfWork;
using Newtonsoft.Json;

namespace GamesCorner.Server.Extensions
{
	public static class WebApplicationSeedDatabaseExtension
	{

		public static async Task<WebApplication> SeedDatabase(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var unitOfWork = services.GetRequiredService<IUnitOfWork>();

			var productsInDatabase = await unitOfWork.ProductRepository.GetAllAsync("");
			if (productsInDatabase.Count() > 0)
				return app;

			var jsonArrayOfGames = Properties.Resources.GamesAsJson;

			var products = JsonConvert.DeserializeObject<List<ProductModel>>(jsonArrayOfGames);

			foreach (var product in products)
			{
				await unitOfWork.ProductRepository.AddAsync(product);
			}

			await unitOfWork.Save();
			return app;

		}
	}
}
