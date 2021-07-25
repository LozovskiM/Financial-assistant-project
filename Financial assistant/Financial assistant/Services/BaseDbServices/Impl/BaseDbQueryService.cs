using Financial_assistant.Models.Contracts;
using Financial_assistant.Services.BaseDbServices.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.BaseDbServices.Impl
{
    public abstract class BaseDbQueryService<T, TDbContext> : BaseDbService<T, TDbContext>, IQueryService<T>
        where T : class, IModel
        where TDbContext : DbContext
    {

        protected BaseDbQueryService(TDbContext context) : base(context) { }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSetAsNoTracking.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await DbSetAsNoTracking.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
