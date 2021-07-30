using Financial_assistant.Models.Contracts;
using Financial_assistant.Services.BaseDbServices.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.BaseDbServices.Impl
{
    public abstract class BaseDbCrudService<T, TDbContext> : BaseDbQueryService<T, TDbContext>, ICrudService<T>
        where T : class, IModel, IDeletedModel
        where TDbContext : DbContext
    {
        protected BaseDbCrudService(TDbContext context) : base(context) { }

        public virtual async Task<T> CreateAsync(T model)
        {
            Create(model);
            await Context.SaveChangesAsync();
            return model;
        }

        protected virtual T Create(T model)
        {
            Context.Add(model);
            return model;
        }

        public virtual async Task<T> UpdateAsync(T model)
        {
            Update(model);
            await Context.SaveChangesAsync();
            return model;
        }

        protected virtual void Update(T model)
        {
            var exists = DbSet.SingleOrDefault(x => x.Id == model.Id);
            if (exists == null) return;
            Context.Update(model);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            Delete(id);
            await Context.SaveChangesAsync();
            return true;
        }

        protected virtual void Delete(int id)
        {
            var exists = DbSet.SingleOrDefault(x => x.Id == id);
            if (exists == null) return;
            exists.IsDeleted = true;
            DbSet.Remove(exists);
        }

        public virtual async Task<bool> RestoreAsync(int id)
        {
            Restore(id);
            await Context.SaveChangesAsync();
            return true;
        }

        protected virtual void Restore(int id)
        {
            var deleted = DbSet.IgnoreQueryFilters().SingleOrDefault(x => x.Id == id);
            if (deleted == null || deleted.IsDeleted == false) return;
            deleted.IsDeleted = false;
            DbSet.Update(deleted);
        }
    }
}
