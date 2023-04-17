using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class GetSpecificUsersHandler : IRequestHandler<GetSpecificUsersRequest, IResult>
{
    public async Task<IResult> Handle(GetSpecificUsersRequest request, CancellationToken cancellationToken)
    {
        if (!request.HttpContext.User.IsInRole("Administrator")) return Results.Unauthorized();

        return Results.Ok(await request.UserRepository.GetSpecificUsersAsync(request.Query));
    }
}