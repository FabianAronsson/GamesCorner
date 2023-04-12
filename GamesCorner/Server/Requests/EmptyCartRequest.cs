using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class EmptyCartRequest : IHttpRequest
    {
        public string OrderId { get; set; }
        public HttpContext HttpContext { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
