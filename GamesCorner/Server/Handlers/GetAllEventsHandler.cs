using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class GetAllEventsHandler : IRequestHandler<GetAllEventsRequest, IResult>
{
    public async Task<IResult> Handle(GetAllEventsRequest request, CancellationToken cancellationToken)
    {
	    var events = await request.UnitOfWork.EventRepository.GetAllAsync();
        return events.Count() == 0 ? Results.NotFound("Event not found") : Results.Ok(events);
    }
}