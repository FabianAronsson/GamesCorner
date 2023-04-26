using GamesCorner.Server.Requests;
using MediatR;

namespace GamesCorner.Server.Handlers;

public class GetProductRecommendationsHandler : IRequestHandler<GetProductRecommendationsRequest, IResult>
{
    public async Task<IResult> Handle(GetProductRecommendationsRequest request, CancellationToken cancellationToken)
    {
        
        if (request.Id == null || request.Id.Length <= 0)
        {
            return Results.Ok((await request.UnitOfWork.ProductRepository.GetAllAsync("")).Take(12));
        }


        var orders = await request.UnitOfWork.OrderRepository.GetSpecificOrders(request.Id);
        if (orders.Count() <= 0)
        {
            return Results.Ok((await request.UnitOfWork.ProductRepository.GetAllAsync("")).Take(12));
        }

        var result = orders.SelectMany(order => order.Products.Select(product => product.ProductId));

        var categories = new List<string>();
        foreach (var id in result)
        {
            categories.AddRange((await request.UnitOfWork.ProductRepository.GetAsync(id)).Category.Split(' '));
        }

        var primaryCategory = "";
        var primaryAmount = 0;
        var sndCategory = "";
        var sndAmount = 0;


        foreach (var category in categories)
        {
            var temp = categories.Count(c => c.Equals(category));
            if (temp > primaryAmount)
            {
                primaryAmount = temp;
                primaryCategory = category;
            }
            else if (temp >= sndAmount)
            {
                sndAmount = temp;
                sndCategory = category;
            }
        }

        var products = (await request.UnitOfWork.ProductRepository.GetAllAsync(""))
            .Where(p => p.Category.Split(' ').Contains(primaryCategory) || p.Category.Split(' ')
                .Contains(sndCategory)).Take(12);

        return Results.Ok(products);
    }
}