using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class GetReviewsFromProductHandler : IRequestHandler<GetReviewsFromProductRequest, IResult>
    {
        public async Task<IResult> Handle(GetReviewsFromProductRequest request, CancellationToken cancellationToken)
        {
            var reviews = request.UnitOfWork.ProductRepository.GetReviewsFromProduct(request.ProductId);
            return Results.Ok(reviews);
        }
    }
}
