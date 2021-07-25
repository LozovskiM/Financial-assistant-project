using Financial_assistant.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.BaseDbServices.Contracts
{
    public interface ICrudService<T> : IQueryService<T> where T : IModel
    {
        Task<T> CreateAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<bool> DeleteAsync(int id);
    }
}
