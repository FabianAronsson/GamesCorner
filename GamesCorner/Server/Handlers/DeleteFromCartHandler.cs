using System.Security.Claims;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class DeleteFromCartHandler: IRequestHandler<DeleteFromCartRequest, IResult>
    {
        public async Task<IResult> Handle(DeleteFromCartRequest request, CancellationToken cancellationToken)
        {
            var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var orders = await request
                .UnitOfWork.OrderRepository
                .GetAllAsync();

            var order = orders.Where(o => o.IsActive)
                .FirstOrDefault(o => o.Id.Equals(userId));

            if (order is null)
            {
                return Results.NotFound("order not found");
            }

            order.Products.Remove(order.Products.FirstOrDefault(i => i.Id.Equals(request.OrderItemId)));
            await request.UnitOfWork.Save();
            return Results.Ok("Item removed");
        }
    }
}
