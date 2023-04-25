using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class AddUserToEventRequest : IHttpRequest
{
	public UserEventModel UserEvent { get; set; }
	public IUnitOfWork UnitOfWork { get; set; }

}