using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests
{
    public class GetProductRequest : IHttpRequest
    {
        public Guid Id { get; set; }
        public HttpRequest HttpRequest { get; set; }
    }
}
