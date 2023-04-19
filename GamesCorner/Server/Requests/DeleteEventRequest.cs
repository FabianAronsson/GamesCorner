using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;
using GamesCorner.Server.Services.AuthService;

namespace GamesCorner.Server.Requests;

public class DeleteEventRequest : IHttpRequest
{
	public EventModel Event { get; set; }
	public IAuthService AuthService { get; set; }
	public IHttpContextAccessor HttpContextAccessor { get; set; }
	public string Token { get; set; }
	public IUnitOfWork UnitOfWork { get; set; }
}