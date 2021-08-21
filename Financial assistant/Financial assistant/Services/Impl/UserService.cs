using Financial_assistant.Models;
using Financial_assistant.Models.DbModels;
using Financial_assistant.Services.BaseDbServices.Impl;
using Financial_assistant.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.Impl
{
    public class UserService : BaseDbCrudService<User, FinancialAssistantDBContext>, IUserService
    {
        public UserService(FinancialAssistantDBContext context) : base(context) { 
            
        }

        public User GetByEmail(string email)
        {
            
            return DbSet.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            return DbSet.FirstOrDefault(u => u.Id == id);
        }
    }
}
