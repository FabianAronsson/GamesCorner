using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class OrderRequest : IHttpRequest
{
    public string Query { get; set; }
    public HttpContext HttpContext { get; set; }

    public IUnitOfWork UnitOfWork { get; set; }
}