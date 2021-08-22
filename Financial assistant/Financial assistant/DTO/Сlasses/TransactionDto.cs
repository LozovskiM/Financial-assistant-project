using Financial_assistant.DTO.Contracts;
using System;

namespace Financial_assistant.DTO.Сlasses
{
    public class TransactionDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int BankAccountId { get; set; }
        public CurrencyDto Currency { get; set; }
        public TransactionTypeDto TransactionType { get; set; }
    }
}
