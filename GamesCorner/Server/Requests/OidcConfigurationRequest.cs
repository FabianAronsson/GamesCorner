using GamesCorner.Server.Requests.Interface;

namespace GamesCorner.Server.Requests;

public class OidcConfigurationRequest : IHttpRequest
{
    public string clientId { get; set; }
    public HttpContext HttpContext { get; set; }
}