using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DataContext.Data;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly StoreContext _storeContext;

        public EventRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<EventModel?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventModel>> GetAllAsync()
        {
            return _storeContext.Events;
        }

        public async Task<EventModel> AddAsync(EventModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<EventModel> UpdateAsync(EventModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<EventModel> DeleteAsync(EventModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<EventModel>> GetAllAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
