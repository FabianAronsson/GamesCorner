using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
	public class UpdateOrderStatusRequest :IHttpRequest
	{
		public string orderId { get; set; }
		public OrderModel Order { get; set; }
		public IUnitOfWork UnitOfWork { get; set; }
		
	}
}
