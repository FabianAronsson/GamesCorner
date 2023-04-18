using DataAccess.Models;
using Duende.IdentityServer.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Repositories.Interfaces;

public interface IOrderRepository:IRepository<OrderModel>
{
    public Task<IEnumerable<OrderModel>> GetSpecificOrders(string email);
}