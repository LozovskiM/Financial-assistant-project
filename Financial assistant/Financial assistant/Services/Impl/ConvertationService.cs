using Financial_assistant.Models;
using Financial_assistant.Models.DbModels;
using Financial_assistant.Services.BaseDbServices.Impl;
using Financial_assistant.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.Impl
{
    public class ConvertationService : BaseDbCrudService<Convertation, FinancialAssistantDBContext>, IConvertationService
    {
        public ConvertationService(FinancialAssistantDBContext context) : base(context) { 
        
        }

        public override async Task<IEnumerable<Convertation>> GetAllAsync()
        {
            return await DbSetAsNoTracking.Include(x => x.CurrencyTo).Include(x => x.CurrencyFrom).ToListAsync();
        }

        public override async Task<Convertation> GetByIdAsync(int id)
        {
            return await DbSetAsNoTracking.Include(x => x.CurrencyTo).Include(x => x.CurrencyFrom).SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<Convertation> UpdateAsync(Convertation model)
        {
            var convertation = DbSet.SingleOrDefault(x => x.Id == model.Id);

            //TODO: i18n
            if (convertation == null) throw new Exception("Convertation not found.");

            convertation.ExchangeRate = model.ExchangeRate;

            DbSet.Update(convertation);

            await Context.SaveChangesAsync();
            return convertation;
        }
    }
}
