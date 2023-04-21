using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class AddReviewHandler : IRequestHandler<AddReviewRequest, IResult>
    {
        public async Task<IResult> Handle(AddReviewRequest request, CancellationToken cancellationToken)
        {
            await request.UnitOfWork.ReviewRepository.AddAsync(request.Review);
            await request.UnitOfWork.Save();
            return Results.Ok("review added");
        }
    }
}
