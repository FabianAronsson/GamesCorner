using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
	public class OrderSuccessRequest :IHttpRequest
	{
		public string Session_Id { get; set; }

		public OrderModel OrderObject { get; set; }

		public IUnitOfWork UnitOfWork { get; set; }

	}
}
