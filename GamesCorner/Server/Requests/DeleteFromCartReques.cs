using DataAccess.UnitOfWork;

namespace GamesCorner.Server.Requests
{
    public class DeleteFromCartReques
    {
        public string ProductId { get; set; }
        public HttpContext HttpContext { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
