﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using DataAccess.DataContext.Data;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
	public class ProductRepository:IProductRepository
    {
        private readonly StoreContext _storeContext;

        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;	
        }
        public async Task<ProductModel?> GetAsync(Guid id)
        {
			var product = await _storeContext.Products.FirstOrDefaultAsync(p=>p.Id.Equals(id));
			return product;
        }

		public async Task<List<ProductModel>> GetAllAsync(string name)
		{
			IEnumerable<ProductModel> products;

			products =  _storeContext.Products.Where(x => x.Name.Contains(name));
		
			return products.ToList();
		}

		public async Task<ProductModel> AddAsync(ProductModel entity)
		{
			await _storeContext.Products.AddAsync(entity);
			return entity;
		}

		public async Task<ProductModel> UpdateAsync(ProductModel entity)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductModel> DeleteAsync(ProductModel entity)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<ProductModel>> GetAllAsync()
		{
			throw new NotImplementedException();
		}
	}
}
