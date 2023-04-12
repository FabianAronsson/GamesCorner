using System.Security.Claims;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class EmptyCartHandler : IRequestHandler<EmptyCartRequest, IResult>
    {
        public async Task<IResult> Handle(EmptyCartRequest request, CancellationToken cancellationToken)
        {
            var orders = await request
                .UnitOfWork.OrderRepository
                .GetAllAsync();

            var order = orders.Where(o => o.IsActive)
                .FirstOrDefault(o => o.CustomerEmail.Equals(request.OrderId));

            if (order is null)
            {
                return Results.NotFound("order not found");
            }
            order.Products.Clear();
            await request.UnitOfWork.Save();
            return Results.Ok("cart is cleared");
        }

    }
}
