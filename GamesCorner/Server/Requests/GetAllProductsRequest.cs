using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
	public class GetAllProductsRequest : IHttpRequest
	{
		public string Name { get; set; }
		public IUnitOfWork UnitOfWork { get; set; }
      
	}
}
