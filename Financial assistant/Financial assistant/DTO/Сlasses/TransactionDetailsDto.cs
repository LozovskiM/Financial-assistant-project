using Financial_assistant.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.DTO.Сlasses
{
    public class TransactionDetailsDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public BankAccountDto BankAccount { get; set; }
        public CurrencyDto Currency { get; set; }
        public TransactionTypeDto TransactionType { get; set; }
    }
}
