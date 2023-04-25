using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class AddToCartRequest : IHttpRequest
    {
        public OrderItem item { get; set; }
        public HttpContext HttpContext { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
