using DataAccess.Models;

namespace GamesCorner.Server.Services.PaymentService;

public interface IPaymentService
{
    string CreateCheckoutSession(List<OrderItem> cartItems);
}