using DataAccess.Repositories.Interfaces;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class DeleteEventHandler : IRequestHandler<DeleteEventRequest, IResult>
{
	private readonly IEventRepository _eventRepository;

	public DeleteEventHandler(IEventRepository eventRepository)
	{
		_eventRepository = eventRepository;
	}

	public async Task<IResult> Handle(DeleteEventRequest request, CancellationToken cancellationToken)
	{
		if (!request.HttpContextAccessor.HttpContext.User.IsInRole("Administrator") &&
		    !request.AuthService.ValidateToken(request.Token))
		{
			return Results.Unauthorized();
		}

		await _eventRepository.DeleteAsync(request.Event);
		await request.UnitOfWork.Save();
		return Results.Ok("Event deleted");
	}
}