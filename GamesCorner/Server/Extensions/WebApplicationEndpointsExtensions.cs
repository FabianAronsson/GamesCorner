﻿using GamesCorner.Server.Requests;

namespace GamesCorner.Server.Extensions;

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
        app.MediateAuthenticateGet<GetAllOrdersRequest>("getAllOrders");
        app.MediateAuthenticateGet<GetSpecificUsersRequest>("getUsers");
        app.MediateGet<GetAllEventsRequest>("events");
        app.MediateAuthenticatePost<AddEventRequest>("addEvent");
        app.MediateAuthenticateDelete<DeleteEventRequest>("deleteEvent");
        app.MediateAuthenticatePut<UpdateEventRequest>("updateEvent");
        app.MediateAuthenticatePost<CreateProductRequest>("createProduct");

        app.MediateAuthenticateDelete<DeleteProductRequest>("deleteProduct");
        app.MediateAuthenticatePut<UpdateProductRequest>("updateProduct");

        app.MediateGet<GetProductRecommendationsRequest>("getRecommendations");
        app.MediateAuthenticatePut<UpdateOrderStatusRequest>("updateOrderStatus");
        app.MediateGet<GetReviewsOfProductRequest>("productReviews");
        app.MediatePost<AddReviewRequest>("addReview");
        app.MediatePost<AddUserToEventRequest>("addUserToEvent");
        app.MediateGet<GetEventRequest>("getEvent");
        return app;
    }
}