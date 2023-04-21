using DataAccess.Models;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class AddUserToEventHandler : IRequestHandler<AddUserToEventRequest, IResult>
{
	public async Task<IResult> Handle(AddUserToEventRequest request, CancellationToken cancellationToken)
	{
		await request.UnitOfWork.IntrestedUserEventRepository.AddUserEventAsync( new UserEventModel()
		{
			Id = request.UserEvent.Id,
			Email = request.UserEvent.Email,
			EventId = request.UserEvent.EventId,
			Name = request.UserEvent.Name,
			Phone = request.UserEvent.Phone
		});
		await request.UnitOfWork.Save();
		return Results.Ok($"User name {request.UserEvent.Name} is added to event");
	}
}