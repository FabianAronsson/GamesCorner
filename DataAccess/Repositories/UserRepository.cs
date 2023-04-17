using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using GamesCorner.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userContext;

        public UserRepository(ApplicationDbContext userContext)
        {
            _userContext = userContext; 
        }
        public async Task<ApplicationUser?> GetAsync(Guid id)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(u=>u.Id.Equals(id));
            return user;
        }
        public async Task<IEnumerable<ApplicationUser>> GetSpecificUsersAsync(string query)
        {
            return await _userContext.Users.Where(user => user.Email.Contains(query)).ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> AddAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> UpdateAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> DeleteAsync(ApplicationUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
