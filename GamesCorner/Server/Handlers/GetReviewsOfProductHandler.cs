using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class GetReviewsOfProductHandler : IRequestHandler<GetReviewsOfProductRequest, IResult>
    {
        public async Task<IResult> Handle(GetReviewsOfProductRequest request, CancellationToken cancellationToken)
        {
            var product = await request.UnitOfWork.ProductRepository.GetAsync(request.ProductId);
            var reviews =await request.UnitOfWork.ReviewRepository.GetReviewsOfProductAsync(product.Id);
            return reviews is null ? Results.NotFound("no reviews for this product") : Results.Ok(reviews);
        }
    }
}
