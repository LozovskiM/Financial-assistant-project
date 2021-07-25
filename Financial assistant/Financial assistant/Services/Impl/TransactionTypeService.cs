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
    public class TransactionTypeService : BaseDbCrudService<TransactionType, FinancialAssistantDBContext>, ITransactionTypeService
    {
        public TransactionTypeService(FinancialAssistantDBContext context) : base(context) { 
        
        }
    }
}
