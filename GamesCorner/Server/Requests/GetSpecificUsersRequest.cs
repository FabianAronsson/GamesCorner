using DataAccess.Repositories.Interfaces;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class GetSpecificUsersRequest : IHttpRequest
{
    public IUserRepository UserRepository { get; set; }
    public HttpContext HttpContext { get; set; }
    public string Query { get; set; }
}