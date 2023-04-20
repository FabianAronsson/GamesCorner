using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class DeleteEventRequest : IHttpRequest
{
	public string EventId { get; set; }
    public IUnitOfWork UnitOfWork { get; set; }
}