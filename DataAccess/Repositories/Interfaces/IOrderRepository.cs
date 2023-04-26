using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IOrderRepository:IRepository<OrderModel>
{
    public Task<IEnumerable<OrderModel>> GetSpecificOrders(string email);
    public Task<OrderModel> UpdateStatusAsync(Guid id, OrderModel entity);
}