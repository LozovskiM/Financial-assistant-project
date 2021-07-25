using Financial_assistant.Models.Contracts;
using System;
using System.Collections.Generic;

#nullable disable

namespace Financial_assistant.Models.DbModels
{
    public class BankAccount : IModel
    {
        public BankAccount()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
