using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductRequest, IResult>
    {
        public async Task<IResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            if (!request.HttpContextAccessor.HttpContext.User.IsInRole("Administrator") &&
                !request.AuthService.ValidateToken(request.Token))
            {
                return Results.Unauthorized();
            }

            await request.UnitOfWork.ProductRepository.AddAsync(request.newProduct);
            await request.UnitOfWork.Save();
            return Results.Ok("Event deleted");
        }
    }
}
