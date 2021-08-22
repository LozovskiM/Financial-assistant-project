using System;

namespace Financial_assistant.DTO.Сlasses
{
    public class TransactionCreateDto
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public int BankAccountId { get; set; }
        public int CurrencyId { get; set; }
        public int TransactionTypeId { get; set; }
    }
}
