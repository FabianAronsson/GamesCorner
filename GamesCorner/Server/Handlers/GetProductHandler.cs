using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class GetProductHandler: IRequestHandler<GetProductRequest, IResult>
    {
        public async Task<IResult> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await request.UnitOfWork.ProductRepository.GetAsync(request.Id);
            return product is null ? Results.NotFound("Product doesn't exist") : Results.Ok(product);
        }
    }
}
