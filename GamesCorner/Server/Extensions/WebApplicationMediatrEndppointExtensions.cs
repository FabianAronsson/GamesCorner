using GamesCorner.Server.Requests.Interface;
using MediatR;

namespace GamesCorner.Server.Extensions;

public static class WebApplicationMediatrEndppointExtensions
{
    public static WebApplication MediateGet<TRequest>(this WebApplication app, string url) where TRequest : IHttpRequest
    {
        app.MapGet(url,
            async (IMediator mediator, [AsParameters] TRequest request) => await mediator.Send(request));
        return app;
    }
}