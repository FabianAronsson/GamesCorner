using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class GetEventRequest : IHttpRequest
{
	public Guid Id { get; set; }
	public IUnitOfWork UnitOfWork { get; set; }
}
