using System.Security.Claims;
using Duende.IdentityServer;
using GamesCorner.Server.Requests;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Stripe;

namespace GamesCorner.Server.Handlers
{
    public class GetActiveOrderItemHandler : IRequestHandler<GetActiveOrderRequest, IResult>
    {
        public async Task<IResult> Handle(GetActiveOrderRequest request, CancellationToken cancellationToken)
        {
            var user = request.HttpContext.User.FindFirstValue(ClaimTypes.Email);
            var order = request
                .UnitOfWork.OrderRepository
                .GetAllAsync()
                .Result
                .Where(o=>o.IsActive)
                .FirstOrDefault(o=>o.CustomerEmail.Equals(user));

            return order is null ? Results.NotFound("Order doesn't exist") : Results.Ok(order);
        }
    }
}
