using DataAccess.Models;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class CreateProductRequest : IHttpRequest
    {
        public ProductModel newProduct { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }
    }
}
