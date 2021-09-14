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
    public class CurrencyService : BaseDbCrudService<Currency, FinancialAssistantDBContext>, ICurrencyService
    {
        public CurrencyService(FinancialAssistantDBContext context) : base(context) { 
        
        }

        public void DeleteCurrencyData()
        {
            Context.Currencies.FromSqlRaw("DELETE FROM Currency DBCC CHECKIDENT('Currency', RESEED, 0)");
            Context.SaveChanges();
        }

        public Currency GetByCode(string code)
        {
            var currency = DbSet.SingleOrDefault(x => x.Code == code);
            return currency;
        }

        public override async Task<Currency> UpdateAsync(Currency model)
        {
            var currency = DbSet.SingleOrDefault(x => x.Id == model.Id);

            //TODO: i18n
            if (currency == null) throw new Exception("Currency not found.");

            currency.Name = model.Name;
            currency.Code = model.Code;

            DbSet.Update(currency);

            await Context.SaveChangesAsync();
            return currency;
        }


    }
}
