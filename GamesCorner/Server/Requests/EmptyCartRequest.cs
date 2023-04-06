using DataAccess.UnitOfWork;

namespace GamesCorner.Server.Requests
{
    public class EmptyCartRequest
    {
        public string OrddrId { get; set; }
        public HttpContext HttpContext { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
