using DataAccess.Models;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class AddEventHandler : IRequestHandler<AddEventRequest, IResult>
{
	public async Task<IResult> Handle(AddEventRequest request, CancellationToken cancellationToken)
	{

		
		await request.UnitOfWork.EventRepository.AddAsync(new EventModel()
		{
			Id = request.Event.Id,
			Name = request.Event.Name,
			Location = request.Event.Location,
			Date = request.Event.Date,
			ImageUrl = request.Event.ImageUrl,
			Price = request.Event.Price,
			Description = request.Event.Description,

		});
		await request.UnitOfWork.Save();
		return Results.Ok("Event added");
	}
}