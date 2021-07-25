using System;
using System.Collections.Generic;

#nullable disable

namespace Financial_assistant.Models.DbModels
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int BankAccountId { get; set; }
        public int CurrencyId { get; set; }
        public int TransactionTypeId { get; set; }

        public virtual BankAccount BankAccount { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual TransactionType TransactionType { get; set; }
    }
}
