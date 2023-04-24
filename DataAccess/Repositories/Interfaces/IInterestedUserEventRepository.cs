using DataAccess.Models;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Repositories.Interfaces;

public interface IInterestedUserEventRepository : IRepository<UserEventModel>
{
	Task<IResult> AddUserEventAsync(UserEventModel userEventModel);
}