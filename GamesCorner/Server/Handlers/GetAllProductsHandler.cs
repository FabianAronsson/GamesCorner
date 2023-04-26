using GamesCorner.Server.Requests;
using MediatR;

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
