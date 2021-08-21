using Financial_assistant.Models;
using Financial_assistant.Models.DbModels;
using Financial_assistant.Services.BaseDbServices.Contracts;
using Financial_assistant.Services.BaseDbServices.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.Contracts
{
    public interface IUserService : ICrudService<User>
    {
        public User GetByEmail(string email);
        public User GetById(int id);
    }
}
