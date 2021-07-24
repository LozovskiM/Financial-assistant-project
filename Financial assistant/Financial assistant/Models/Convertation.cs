using System;
using System.Collections.Generic;

#nullable disable

namespace Financial_assistant.Models
{
    public class Convertation
    {
        public int Id { get; set; }
        public int CurrencyFromId { get; set; }
        public int CurrencyToId { get; set; }
        public double ExchangeRate { get; set; }

        public virtual Currency CurrencyFrom { get; set; }
        public virtual Currency CurrencyTo { get; set; }
    }
}
