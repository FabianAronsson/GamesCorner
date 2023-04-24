using System.ComponentModel;
using System.Security.Claims;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers
{
    public class AddToCartHandler : IRequestHandler<AddToCartRequest, IResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddToCartHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;   
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult> Handle(AddToCartRequest request, CancellationToken cancellationToken)
        {
            var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var email = (await _userRepository.GetAsync(Guid.Parse(userId))).Email;

            var orders = await _unitOfWork.OrderRepository
                .GetAllAsync();

            var order = orders
                .FirstOrDefault(o => o.IsActive && o.CustomerEmail.Equals(email));

            

            if (order is null)
            {
                await _unitOfWork.OrderRepository.AddAsync(new OrderModel
                {
                    CustomerEmail = (await _userRepository.GetAsync(Guid.Parse(userId))).Email,
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    Products = new List<OrderItem> { request.item},
                    PurchaseDate = DateTime.UtcNow
                });
            }
            else
            {
                var product = await _unitOfWork.ProductRepository.GetAsync(request.item.ProductId);

                var existing = order.Products.FirstOrDefault(o => o.ProductId.Equals(product.Id));
                if (existing is not null)
                {
                    existing.Amount++;
                }
                else
                {
                    if (product != null)
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
            }
            await _unitOfWork.Save();
            return Results.Ok("Item added");
        }
    }
}
