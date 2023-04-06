using System.Security.Claims;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class DeleteFromCartHandler: IRequestHandler<DeleteFromCartRequest, IResult>
    {
        public async Task<IResult> Handle(DeleteFromCartRequest request, CancellationToken cancellationToken)
        {
            var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var orders = await request
                .UnitOfWork.OrderRepository
                .GetAllAsync();

            var email = (await request.UnitOfWork.UserRepository.GetAsync(Guid.Parse(userId))).Email;
            var order = orders.Where(o => o.IsActive)
                .FirstOrDefault(o => o.CustomerEmail.Equals(email));

            var item = order.Products.FirstOrDefault(o => o.Id.Equals(request.OrderItemId));
            if (item is not null && item.Amount != 0)
            {
                item.Amount -= item.Amount;
            }
            else
            {
                order.Products.Remove(item);
            }
            await request.UnitOfWork.Save();
            return Results.Ok();
        }
    }
}
