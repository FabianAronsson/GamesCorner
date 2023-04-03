using GamesCorner.Server.Requests;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;

namespace GamesCorner.Server.Handlers;

public class OidcConfigurationHandler : IRequestHandler<OidcConfigurationRequest, IResult>
{

    public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

    public OidcConfigurationHandler(IClientRequestParametersProvider clientRequestParametersProvider)
    {
        ClientRequestParametersProvider = clientRequestParametersProvider;
    }
    public async Task<IResult> Handle(OidcConfigurationRequest request, CancellationToken cancellationToken)
    {
        var parameters = ClientRequestParametersProvider.GetClientParameters(request.HttpContext, request.clientId);
        return Results.Ok(parameters);
    }
}