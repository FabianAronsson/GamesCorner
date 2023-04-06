using DataAccess.Models;
using GamesCorner.Server.Services.PaymentService;

namespace GamesCorner.Server.Requests;

public class CreateSessionIdRequest
{
    public List<OrderItem> Cart { get; set; }
    public IPaymentService PaymentService { get; set; }
}