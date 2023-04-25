using System.ComponentModel;
using System.Security.Claims;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, IResult>
    {
        private readonly IUserRepository _userRepository;

        public AddToCartHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IResult> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            
            var email = (await _userRepository.GetAsync(Guid.Parse(userId))).Email;

            var orders = await request.UnitOfWork.OrderRepository.GetAllAsync();

            var order = orders.FirstOrDefault(o => o.IsActive && o.CustomerEmail.Equals(email));

            var product = await request.UnitOfWork.ProductRepository.GetAsync(request.item.ProductId);

			if (order is null)
            {
	            await request.UnitOfWork.OrderRepository.AddAsync(new OrderModel()
	            {
		            CustomerEmail = email,
		            Id = Guid.NewGuid(),
		            IsActive = true,
		            Products = new List<OrderItem>(){new OrderItem(){Amount = 1, Id = Guid.NewGuid(), ProductId = product.Id}},
		            PurchaseDate = DateTime.UtcNow
				});
	            await request.UnitOfWork.Save();
            }
            else
            {
				var existing = order.Products.FirstOrDefault(o => o.ProductId.Equals(product.Id));
				if (existing is not null)
				{
					existing.Amount++;
				}
				else
				{
					var newProduct = new OrderItem()
					{
						Id = Guid.NewGuid(),
						Amount = 1,
						ProductId = product.Id
					};
					order.Products.Add(newProduct);
				}
				
			}
			await request.UnitOfWork.Save();
			return Results.Ok("Item added");
        }
    }
}
