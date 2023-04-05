using System.Security.Claims;
using Duende.IdentityServer;
using GamesCorner.Server.Requests;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using NuGet.Protocol;
using Stripe;

namespace GamesCorner.Server.Handlers
{
    public class GetActiveOrderItemHandler : IRequestHandler<GetActiveOrderRequest, IResult>
    {
        public async Task<IResult> Handle(GetActiveOrderRequest request, CancellationToken cancellationToken)
        {
            var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var orders = await request
                .UnitOfWork.OrderRepository
                .GetAllAsync();

           var order = orders.Where(o => o.IsActive)
            .FirstOrDefault(o => o.Id.Equals(userId));

            return order is null ? Results.NotFound("Order doesn't exist") : Results.Ok(order);
        }
    }
}
