using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class GetAllEventsRequest : IHttpRequest
{
	public IUnitOfWork UnitOfWork { get; set; }
}