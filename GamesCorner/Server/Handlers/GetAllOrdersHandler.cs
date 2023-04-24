using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, IResult>
{
    public async Task<IResult> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
    {
        return Results.Ok(await request.UnitOfWork.OrderRepository.GetAllAsync());
    }
}