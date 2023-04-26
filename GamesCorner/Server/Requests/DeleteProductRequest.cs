using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class DeleteProductRequest : IHttpRequest
    {
        public Guid productId { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
