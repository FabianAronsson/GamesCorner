using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class UpdateOrderStatusHandler :IRequestHandler<UpdateOrderStatusRequest, IResult>
{
	public async Task<IResult> Handle(UpdateOrderStatusRequest request, CancellationToken cancellationToken)
	{
		await request.UnitOfWork.OrderRepository.UpdateStatusAsync(Guid.Parse(request.orderId), request.Order);
		await request.UnitOfWork.Save();
		return Results.Ok();
	}
}