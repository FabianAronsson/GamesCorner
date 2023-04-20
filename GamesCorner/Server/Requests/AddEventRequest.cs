using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class AddEventRequest : IHttpRequest
{
	public EventModel Event { get; set; }
    public IUnitOfWork UnitOfWork { get; set; }
}