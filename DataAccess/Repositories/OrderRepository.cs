﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<OrderModel?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> AddAsync(OrderModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> UpdateAsync(OrderModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderModel> DeleteAsync(OrderModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
