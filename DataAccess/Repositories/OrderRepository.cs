using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataContext.Data;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.Extensions;
using IdentityModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext _storeContext;

        public OrderRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<OrderModel?> GetAsync(Guid id)
        {
            return _storeContext.Orders.Include(o => o.Products).FirstOrDefault(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
			return  _storeContext.Orders;
		}
        public async Task<IEnumerable<OrderModel>> GetSpecificOrders(string email)
        {
            var result = await _storeContext.Orders.Include(x => x.Products).Where(c => c.CustomerEmail.Equals(email)).ToListAsync();
            return result;
        }

        public async Task<OrderModel> AddAsync(OrderModel entity)
        {

			 _storeContext.Orders.Add(entity); 
			return entity;
        }

        public async Task<OrderModel> UpdateAsync(OrderModel entity)
        {
            _storeContext.Orders.Update(entity);
            return entity;
        }

        public async Task<OrderModel> UpdateStatusAsync(Guid id, OrderModel entity)
        {
	        var oldOrder = _storeContext.Orders.FirstOrDefault(x => x.Id == id);
	        
            oldOrder.Status = entity.Status;
	        
            return oldOrder;

        }

		public async Task<OrderModel> DeleteAsync(OrderModel entity)
        {
            throw new NotImplementedException();
        }

    }
}
