using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
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

			var allOrders = await request.UnitOfWork.OrderRepository.GetAllAsync();

			var activeOrder = allOrders.FirstOrDefault(o => o.CustomerEmail.Equals(customerEmail) && o.IsActive == true);

			if(activeOrder != null)
			{
				activeOrder.IsActive = false;
				activeOrder.PurchaseDate = DateTime.UtcNow;
				await request.UnitOfWork.OrderRepository.UpdateAsync(activeOrder);
			}
			else
			{
				activeOrder = request.OrderObject;
				activeOrder.CustomerEmail = customerEmail;
				activeOrder.IsActive = false;
				activeOrder.PurchaseDate= DateTime.UtcNow;
				await request.UnitOfWork.OrderRepository.AddAsync(activeOrder);
			}
			await request.UnitOfWork.Save();
			return Results.Ok();

		}
	}
}
