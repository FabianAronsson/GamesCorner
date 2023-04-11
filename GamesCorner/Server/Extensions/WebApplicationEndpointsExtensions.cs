using GamesCorner.Server.Requests;

namespace GamesCorner.Server.Extensions;
using MediatR;

public static class WebApplicationEndpointsExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MediateGet<OidcConfigurationRequest>("_configuration/{clientId}");
        app.MediateGet<GetProductRequest>("getProduct");
        app.MediatePut<OrderSuccessRequest>("orderSuccess");
        app.MediateGet<GetAllProductsRequest>("search");
        //app.MediatePost<CreateSessionIdRequest>("checkout");
        return app;
    }
}