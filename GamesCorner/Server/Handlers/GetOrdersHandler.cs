using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class GetOrdersHandler : IRequestHandler<OrderRequest, IResult>
{
    public async Task<IResult> Handle(OrderRequest request, CancellationToken cancellationToken)
    {
        if (!request.HttpContext.User.IsInRole("Administrator")) return Results.Unauthorized();

        var result = await request.UnitOfWork.OrderRepository.GetSpecificOrders(request.Query);
        return Results.Ok(result);
    }
}