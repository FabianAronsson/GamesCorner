using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class GetEventHandler : IRequestHandler<GetEventRequest, IResult>
{
	public async Task<IResult> Handle(GetEventRequest request, CancellationToken cancellationToken)
	{
		var Event = await request.UnitOfWork.EventRepository.GetAsync(request.Id);
		return Event is null ? Results.NotFound("Event doesn't exist") : Results.Ok(Event);
	}
}
