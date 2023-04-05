using DataAccess.UnitOfWork;

namespace GamesCorner.Server.Requests
{
    public class GetActiveOrderRequest
    {
        public string UserId { get; set; }
        public HttpContext HttpContext { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
