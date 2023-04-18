using System.Security.Claims;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Duende.IdentityServer;
using GamesCorner.Server.Requests;
using GamesCorner.Shared.Dtos;
using MediatR;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using NuGet.Protocol;
using Stripe;

namespace GamesCorner.Server.Handlers
{
    public class GetActiveOrderHandler : IRequestHandler<GetActiveOrderRequest, IResult>
    {
        private readonly IUserRepository _userRepository;

        public GetActiveOrderHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IResult> Handle(GetActiveOrderRequest request, CancellationToken cancellationToken)
        {
            var userId = request.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var orders = await request
                .UnitOfWork.OrderRepository
                .GetAllAsync();

            var email = (await _userRepository.GetAsync(Guid.Parse(userId)))?.Email;
            var order = orders.Where(o => o.IsActive)
                .FirstOrDefault(o => o.CustomerEmail.Equals(email));

            return order is null? Results.Ok(): Results.Ok(ConvertToDto(order));
        }

        private OrderDto? ConvertToDto(OrderModel model)
        {
            List<OrderItemDto>? items = new List<OrderItemDto>();
            foreach (var item in model.Products)
            {
                items.Add(new OrderItemDto()
                {
                    Amount = item.Amount,
                    Id = item.Id.ToString(),
                    ProductId = item.ProductId.ToString()
                });
            };

            return new OrderDto()
            {
                CustomerEmail = model.CustomerEmail,
                Id = model.Id.ToString(),
                IsActive = model.IsActive,
                Products = items,
                PurchaseDate = model.PurchaseDate
            };
        }
    }
}
