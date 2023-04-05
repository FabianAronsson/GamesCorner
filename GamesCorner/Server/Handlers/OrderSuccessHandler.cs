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
			var session = new Session();

			try
			{
				session = await sessionService.GetAsync(request.Session_Id);

			}
			catch (Exception e)
			{
				Results.BadRequest("Invalid Session Id");
				throw;
			}

			var customerEmail = session.CustomerDetails.Email;

			await request.UnitOfWork.OrderRepository.UpdateAsync(request.OrderObject);

			return Results.Ok();

		}
	}
}
