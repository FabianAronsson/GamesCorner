using DataAccess.Models;

namespace GamesCorner.Server.Services.PaymentService;

public interface IPaymentService
{
    Task<string> CreateCheckoutSession(List<OrderItem> cartItems);
}