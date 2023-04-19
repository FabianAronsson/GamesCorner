using DataAccess.Models;
using GamesCorner.Server.Requests;

namespace GamesCorner.Server.Extensions;
using MediatR;

public static class WebApplicationEndpointsExtensions
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MediateGet<OidcConfigurationRequest>("_configuration/{clientId}");
        app.MediateGet<GetProductRequest>("getProduct");
        app.MediateGet<GetActiveOrderRequest>("getActiveOrder");
        app.MediatePost<AddToCartRequest>("addToCart");
        app.MediateDelete<DeleteFromCartRequest>("deleteItemFromCart");
        app.MediateDelete<EmptyCartRequest>("emptyCart");
        app.MediatePut<OrderSuccessRequest>("orderSuccess");
        app.MediateGet<GetAllProductsRequest>("search");
        app.MediatePost<CreateSessionIdRequest>("checkout");
        app.MediateGet<OrderRequest>("getOrders");

        app.MediateGet<GetSpecificUsersRequest>("getUsers");

        app.MediateGet<GetAllEventsRequest>("events");
        app.MediatePost<AddEventRequest>("addEvent");
        app.MediateDelete<DeleteEventRequest>("deleteEvent");

        app.MediatePost<CreateProductRequest>("createProduct");
        app.MediateDelete<DeleteProductRequest>("deleteProduct");
        return app;
    }
}