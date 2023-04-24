using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IProductRepository : IRepository<ProductModel>
{
	Task<List<ProductModel>> GetAllAsync(string name);
    Task<ProductModel> UpdateAsync(Guid id, ProductModel entity);
}