using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IReviewRepository : IRepository<ReviewModel> 
    {
        Task<List<ReviewModel>> GetReviewsOfProductAsync(Guid productId);
    }
}
