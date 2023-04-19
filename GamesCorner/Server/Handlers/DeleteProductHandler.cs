using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, IResult>
    {
        public async Task<IResult> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            if (!request.HttpContextAccessor.HttpContext.User.IsInRole("Administrator") &&
                !request.AuthService.ValidateToken(request.Token))
            {
                return Results.Unauthorized();
            }

            var product = await request.UnitOfWork.ProductRepository.GetAsync(request.productId);
            await request.UnitOfWork.ProductRepository.DeleteAsync(product);
            await request.UnitOfWork.Save();
            return Results.Ok("product deleted");
        }
    }
}
