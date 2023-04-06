using System.Security.Claims;
using DataAccess.Models;
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
               await request.UnitOfWork.OrderRepository.AddAsync(new OrderModel()
                {
                    CustomerEmail = (await request.UnitOfWork.UserRepository.GetAsync(Guid.Parse(userId))).Email,
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    Products = new List<OrderItem>(){request.item},
                    PurchaseDate = DateTime.UtcNow
                });
            }
            else
            {
                var existing = order.Products.FirstOrDefault(o => o.Id.Equals(request.item.Id));
                if (existing is not null)
                {
                    existing.Amount += existing.Amount;
                }
                else
                {
                    order.Products.Add(request.item);
                }
            }
            await request.UnitOfWork.Save();

            return Results.Ok("Item added");
        }
    }
}
