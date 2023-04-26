using DataAccess.DataContext.Data;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly StoreContext _storeContext;

        public ReviewRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<ReviewModel?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewModel> AddAsync(ReviewModel entity)
        {
            await _storeContext.Reviews.AddAsync(entity);
            return entity;
        }

        public async Task<ReviewModel> UpdateAsync(ReviewModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ReviewModel> DeleteAsync(ReviewModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReviewModel>> GetReviewsOfProductAsync(Guid productId)
        {
            var reviews = await _storeContext.Reviews
                .Where(r => r.ProductId == productId)
                .Select(r => new ReviewModel
                {
                    Id = r.Id,
                    Content = r.Content,
                    UserEmail = r.UserEmail,
                    ProductId = r.ProductId,
                    Rating = r.Rating,
                    CreatedDateTime = r.CreatedDateTime
                })
                .ToListAsync();
            return reviews;
        }
    }
}
