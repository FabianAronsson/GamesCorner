using System.Security.Claims;
using GamesCorner.Server.Requests;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GamesCorner.Server.Handlers
{
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, IResult>
    {
        public async Task<IResult> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var orders = await request
                .UnitOfWork.OrderRepository
                .GetAllAsync();

            var order = orders.Where(o => o.IsActive)
                .FirstOrDefault(o => o.Id.Equals(userId));

            if (order is null)
            {
                return Results.NotFound();
            }
            order.Products.Add(request.item);
            return Results.Ok("Item added");
        }
    }
}
