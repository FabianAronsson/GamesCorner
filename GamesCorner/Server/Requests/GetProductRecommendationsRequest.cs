using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class GetProductRecommendationsRequest : IHttpRequest
{
    public IUnitOfWork UnitOfWork { get; set; }
    public string Id { get; set; }
}