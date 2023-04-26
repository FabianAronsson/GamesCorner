using DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<EventModel>
    {
        Task<List<EventModel>> GetAllAsync(string name);
        Task<IResult> DeleteByIdAsync(string id);
        Task<EventModel> UpdateAsync(Guid id, EventModel entity);

    }
}
