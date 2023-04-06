using System.Reflection;
using System.Resources;
using DataAccess.DataContext.Data;
using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
using Duende.IdentityServer.Models;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace GamesCorner.Server.Extensions
{
	public static class WebApplicationSeedDatabaseExtension
	{

		public static async Task<WebApplication> SeedDatabase(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var UnitOfWork = services.GetRequiredService<IUnitOfWork>();

			string test = "";
			var productsInDatabase = await UnitOfWork.ProductRepository.GetAllAsync( test);
			if (productsInDatabase.Count() > 0)
				return app;



			var json = Properties.Resources.GamesAsJson;



			var products = JsonConvert.DeserializeObject<List<ProductModel>>(json);

			foreach (var product in products)
			{
				await UnitOfWork.ProductRepository.AddAsync(product);
			}

			await UnitOfWork.Save();
			return app;

		}
	}
}
