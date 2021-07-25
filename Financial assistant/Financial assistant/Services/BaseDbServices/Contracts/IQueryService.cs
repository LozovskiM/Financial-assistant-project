using Financial_assistant.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.BaseDbServices.Contracts
{
    public interface IQueryService<T> where T : IModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
