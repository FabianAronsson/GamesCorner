using DataAccess.Models;
using GamesCorner.Server.Requests.Interface;
using GamesCorner.Server.Services.PaymentService;

namespace GamesCorner.Server.Requests;

public class CreateSessionIdRequest : IHttpRequest
{
    public List<OrderItem> Cart { get; set; }
    public IPaymentService PaymentService { get; set; }
}