using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class UpdateEventHandler : IRequestHandler<UpdateEventRequest, IResult>
{
	public async Task<IResult> Handle(UpdateEventRequest request, CancellationToken cancellationToken)
	{
		await request.UnitOfWork.EventRepository.UpdateAsync(request.Event.Id, request.Event);
		await request.UnitOfWork.Save();
		return Results.Ok();
	}
}
