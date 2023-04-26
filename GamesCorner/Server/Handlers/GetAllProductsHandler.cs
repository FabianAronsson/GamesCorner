using DataAccess.Models;
using GamesCorner.Server.Requests;
using MediatR;
using Stripe;
using System.IdentityModel.Tokens.Jwt;

namespace GamesCorner.Server.Handlers
{
	public class GetAllProductsHandler : IRequestHandler<GetAllProductsRequest, IResult>
	{
		public async Task<IResult> Handle(GetAllProductsRequest request, CancellationToken cancellationToken)
		{
			var products = await request.UnitOfWork.ProductRepository.GetAllAsync(request.Name);

			 return products.Count == 0 ? Results.NotFound("Product not found") : Results.Ok(products);
		}
	}
}
