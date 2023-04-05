using DataAccess.Models;
using Stripe;
using Stripe.Checkout;

namespace GamesCorner.Server.Services.PaymentService;

public class PaymentService : IPaymentService
{
    public PaymentService()
    {
        StripeConfiguration.ApiKey =
            "SECRET STRIPE KEY"; //TODO: ADD SK KEY
    }
    public string CreateCheckoutSession(List<OrderItem> cartItems)
    {
        public string CreateCheckoutSession(List<OrderItem> cartItems)
        {
            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(c => lineItems.Add(new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    UnitAmountDecimal = (decimal?)(c.Product.Price * 100),
                    Currency = "usd",
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = c.Product.Name,
                        Images = new List<string>() { c.Product.ImageUrl }
                    }
                },
                Quantity = c.Amount
            }));
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>()
                {
                    "card"
                },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7098" + "/store/order-success?session_id={CHECKOUT_SESSION_ID}",
                CancelUrl = "https://localhost:7098" + "/store/cart",
            };
            var service = new SessionService();
            var session = service.Create(options);

            session.SuccessUrl += session.Id;

            return session.Id;
        }
    }
}