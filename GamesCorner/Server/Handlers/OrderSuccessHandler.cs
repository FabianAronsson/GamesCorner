using Duende.IdentityServer.Models;
using GamesCorner.Server.Requests;
using MediatR;
using Stripe.Checkout;

namespace GamesCorner.Server.Handlers
{
	public class OrderSuccessHandler: IRequestHandler<OrderSuccessRequest, IResult>
	{
		public async Task<IResult> Handle(OrderSuccessRequest request, CancellationToken cancellationToken)
		{
			
			var sessionService = new SessionService();

			var session = await sessionService.GetAsync(request.Session_Id);

			var customerEmail = session.CustomerDetails.Email;

			await request.UnitOfWork.OrderRepository.AddAsync(request.OrderObject);

			return Results.Ok();


		}
	}
}
