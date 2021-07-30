using Financial_assistant.DTO.Contracts;

namespace Financial_assistant.DTO.Сlasses
{
    public class ConvertationDto : IDto
    {
        public int Id { get; set; }
        public CurrencyDto CurrencyFrom { get; set; }
        public CurrencyDto CurrencyTo { get; set; }
        public double ExchangeRate { get; set; }
    }
}
