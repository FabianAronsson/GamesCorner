using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;
using MediatR;

namespace GamesCorner.Server.Requests;

public class GetProductRecommendationsRequest : IHttpRequest
{
    public IUnitOfWork UnitOfWork { get; set; }
    public IUserRepository UserRepository { get; set; }
    public string Id { get; set; }
}