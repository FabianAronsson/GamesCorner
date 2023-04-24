using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IReviewRepository : IRepository<ReviewModel> 
    {
        Task<List<ReviewModel>> GetReviewsOfProductAsync(Guid productId);
    }
}
