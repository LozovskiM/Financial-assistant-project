using Financial_assistant.DTO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.DTO.Сlasses
{
    public class BankAccountDetailsDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public CurrencyDto Currency { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}
