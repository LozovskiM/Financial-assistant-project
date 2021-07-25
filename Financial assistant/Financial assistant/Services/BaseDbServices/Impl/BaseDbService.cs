using Financial_assistant.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Financial_assistant.Services.BaseDbServices.Impl
{
    public abstract class BaseDbService<TDbContext> where TDbContext : DbContext
    {
        public TDbContext Context { get; }

        protected BaseDbService(TDbContext context)
        {
            Context = context;
        }
    }

    public abstract class BaseDbService<T, TDbContext> : BaseDbService<TDbContext>
        where T : class, IModel
        where TDbContext : DbContext
    {
        private DbSet<T> _dbSet;

        protected internal DbSet<T> DbSet
        {
            get => _dbSet;
            internal set => _dbSet = value;
        }

        protected internal IQueryable<T> DbSetAsNoTracking { get; set; }

        protected BaseDbService(TDbContext context) : base(context)
        {
            _dbSet = Context.Set<T>();
            DbSetAsNoTracking = _dbSet.AsNoTracking();
        }
    }
}
