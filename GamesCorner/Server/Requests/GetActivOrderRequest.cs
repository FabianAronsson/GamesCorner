using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class GetActiveOrderRequest : IHttpRequest
    {
        public HttpContext HttpContext { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
