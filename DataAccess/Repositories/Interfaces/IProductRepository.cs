using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IProductRepository : IRepository<ProductModel>
{
	Task<List<ProductModel>> GetAllAsync(string name);
	Task<IEnumerable<ReviewModel>> GetReviewsFromProduct(Guid productId);
}