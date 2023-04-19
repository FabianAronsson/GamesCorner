using GamesCorner.Server.Requests;
using GamesCorner.Shared.Dtos;
using MediatR;

namespace GamesCorner.Server.Handlers
{
	public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, IResult>
	{
		public async Task<IResult> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
		{
			if (!request.HttpContextAccessor.HttpContext.User.IsInRole("Administrator") &&
			    !request.AuthService.ValidateToken(request.Token))
			{
				return Results.Unauthorized();
			}


			await request.UnitOfWork.ProductRepository.UpdateAsync(request.productId, request.Product);
			await request.UnitOfWork.Save();

			return Results.Ok();

		}
	}
}
