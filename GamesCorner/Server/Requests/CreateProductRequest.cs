using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class CreateProductRequest : IHttpRequest
    {
        public Guid productId { get; set; }
        public ProductModel newProduct { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public string Token { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
