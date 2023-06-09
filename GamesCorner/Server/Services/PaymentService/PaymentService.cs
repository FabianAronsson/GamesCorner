﻿using DataAccess.Models;
using DataAccess.UnitOfWork;
using Stripe;
using Stripe.Checkout;

namespace GamesCorner.Server.Services.PaymentService;

public class PaymentService : IPaymentService
{
    private readonly IUnitOfWork _unitOfWork;

    public PaymentService(IUnitOfWork unitOfWork)
    {
        StripeConfiguration.ApiKey =
			"sk_test_51MtRi3E3iLgJQuf0ow0vbPN8EwjTdOoSTz4juIwvrZvGs9IVyK8RxFkn1PFmogIPD1QOCAYvC8NEC7dHdKXcAPiM00O0WjCYPL"; //TODO: ADD SK KEY IN KEYVAULT
        _unitOfWork = unitOfWork;
    }

    public async Task<string> CreateCheckoutSession(List<OrderItem> cartItems)
    {
        //Get the products from the database
        var convertedCartItems = new List<ProductModel?>();
        foreach (var cartItem in cartItems)
        {
            convertedCartItems.Add(await _unitOfWork.ProductRepository.GetAsync(cartItem.ProductId));
        }

        //Convert the products into line items for stripe
        var lineItems = new List<SessionLineItemOptions>();
        convertedCartItems.ForEach(c => lineItems.Add(new SessionLineItemOptions()
        {
            PriceData = new SessionLineItemPriceDataOptions()
            {
                UnitAmountDecimal = (decimal?)(c.Price * 100),
                Currency = "sek",
                ProductData = new SessionLineItemPriceDataProductDataOptions()
                {
                    Name = c.Name,
                    Images = new List<string>() { c.ImageUrl }
                }
            },
            Quantity = cartItems.FirstOrDefault(p => p.ProductId.Equals(c.Id)).Amount
        }));
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string>()
                {
                    "card"
                },
            LineItems = lineItems,
            Mode = "payment",
            
            SuccessUrl = "https://gamescorner.azurewebsites.net" + "/OrderSuccess/{CHECKOUT_SESSION_ID}",
            CancelUrl = "https://gamescorner.azurewebsites.net" + "/ShoppingCart",
        };


        var service = new SessionService();
        var session = await service.CreateAsync(options);

        session.SuccessUrl += session.Id;

        return session.Id;
    }
}