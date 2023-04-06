using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class CreateSessionIdHandler : IRequestHandler<CreateSessionIdRequest, IResult>
{
    public async Task<IResult> Handle(CreateSessionIdRequest request, CancellationToken cancellationToken)
    {
        var session = await request.PaymentService.CreateCheckoutSession(request.Cart);
        return Results.Ok(session);
    }
}