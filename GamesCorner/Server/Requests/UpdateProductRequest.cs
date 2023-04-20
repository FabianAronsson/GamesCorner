using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
	public class UpdateProductRequest :IHttpRequest
	{
		public Guid productId { get; set; }
		public ProductModel Product { get; set; }
		public IUnitOfWork UnitOfWork { get; set; }
	}
}
