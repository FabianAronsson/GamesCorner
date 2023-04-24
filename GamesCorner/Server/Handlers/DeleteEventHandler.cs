using DataAccess.Repositories.Interfaces;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, IResult>
{
	public async Task<IResult> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
	{
        await request.UnitOfWork.EventRepository.DeleteByIdAsync(request.EventId);
		await request.UnitOfWork.Save();
		return Results.Ok("Event deleted");
	}
}