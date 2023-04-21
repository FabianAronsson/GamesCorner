using DataAccess.DataContext.Data;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DataAccess.Repositories;

public class IntrestedUserEventRepository : IIntrestedUserEventRepository
{
	private readonly StoreContext _storeContext;

	public IntrestedUserEventRepository(StoreContext storeContext)
	{
		_storeContext = storeContext;
	}
	public async Task<UserEventModel?> GetAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public async Task<IEnumerable<UserEventModel>> GetAllAsync()
	{
		throw new NotImplementedException();

	}

	public async Task<UserEventModel> AddAsync(UserEventModel entity)
	{
		
		throw new NotImplementedException();
	}

	public async Task<UserEventModel> UpdateAsync(UserEventModel entity)
	{
		throw new NotImplementedException();
	}

	public async Task<UserEventModel> DeleteAsync(UserEventModel entity)
	{
		throw new NotImplementedException();
	}

	public async Task<IResult> AddUserEventAsync(UserEventModel userEventModel)
	{
		var userToAdd = _storeContext.EventUsers.FirstOrDefault(x => x.Email == userEventModel.Email && x.EventId == userEventModel.EventId);

		if (userToAdd == null)
		{
			_storeContext.EventUsers.Add(userEventModel);
			return Results.Ok("User added to event");
		}
		return Results.BadRequest("User already added to event");
		
	}
}
