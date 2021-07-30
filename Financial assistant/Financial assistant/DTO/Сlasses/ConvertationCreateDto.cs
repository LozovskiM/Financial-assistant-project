﻿using Financial_assistant.DTO.Contracts;

namespace Financial_assistant.DTO.Сlasses
{
    public class ConvertationCreateDto : IDto
    {
        public int Id { get; set; }
        public int CurrencyFromId { get; set; }
        public int CurrencyToId { get; set; }
        public double ExchangeRate { get; set; }
    }
}
