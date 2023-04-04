using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class GetProductRequest : IHttpRequest
    {
        public Guid Id { get; set; }
        public UnitOfWork UnitOfWork { get; set; }
    }
}
