using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IProductRepository : IRepository<ProductModel>
{
	Task<List<ProductModel>> GetAllAsync(string name);
}