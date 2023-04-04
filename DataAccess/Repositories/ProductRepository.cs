using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
	public class ProductRepository:IProductRepository
	{
		public async Task<ProductModel> GetAsync(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<ProductModel>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<ProductModel> AddAsync(ProductModel entity)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductModel> UpdateAsync(ProductModel entity)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductModel> DeleteAsync(ProductModel entity)
		{
			throw new NotImplementedException();
		}
	}
}
