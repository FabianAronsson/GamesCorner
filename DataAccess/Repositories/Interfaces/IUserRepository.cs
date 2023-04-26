using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IUserRepository :IRepository<ApplicationUser>
{
    public Task<IEnumerable<ApplicationUser>> GetSpecificUsersAsync(string query);
}