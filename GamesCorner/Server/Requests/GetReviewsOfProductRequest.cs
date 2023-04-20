using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class GetReviewsOfProductRequest : IHttpRequest
    {
         public Guid ProductId { get; set; }
         public IUnitOfWork UnitOfWork { get; set; }
    }
}
