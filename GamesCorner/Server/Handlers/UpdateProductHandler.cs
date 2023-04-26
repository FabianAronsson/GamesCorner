using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
	public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, IResult>
	{
		public async Task<IResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
		{
		
			await request.UnitOfWork.ProductRepository.UpdateAsync(request.productId, request.Product);
			await request.UnitOfWork.Save();

			return Results.Ok();

		}
	}
}
