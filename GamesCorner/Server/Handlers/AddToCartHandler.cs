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
            var order = await request.UnitOfWork.OrderRepository.GetAsync(request.OrderId);
            order.Products.Add(request.item);
            return Results.Ok();
        }
    }
}
