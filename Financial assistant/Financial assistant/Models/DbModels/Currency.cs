using Financial_assistant.Models.Contracts;
using System;
using System.Collections.Generic;

#nullable disable

namespace Financial_assistant.Models.DbModels
{
    public class Currency : IModel, IDeletedModel
    {
        public Currency()
        {
            BankAccounts = new HashSet<BankAccount>();
            ConvertationCurrencyFroms = new HashSet<Convertation>();
            ConvertationCurrencyTos = new HashSet<Convertation>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Convertation> ConvertationCurrencyFroms { get; set; }
        public virtual ICollection<Convertation> ConvertationCurrencyTos { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public bool IsDeleted { get; set; }
    }
}
