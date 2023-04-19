using System.Security.Claims;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using GamesCorner.Server.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Plugins;

namespace GamesCorner.Server.Handlers;

public class AddEventHandler : IRequestHandler<AddEventRequest, IResult>
{
	public async Task<IResult> Handle(AddEventRequest request, CancellationToken cancellationToken)
	{

		if (!request.HttpContextAccessor.HttpContext.User.IsInRole("Administrator") && 
		    !request.AuthService.ValidateToken(request.Token))
		{
			return Results.Unauthorized();
		}
		await request.UnitOfWork.EventRepository.AddAsync(new EventModel()
		{
			Id = Guid.NewGuid(),
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