namespace Financial_assistant.DTO.Сlasses
{
    public class BankAccountCreateDto
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public int UserId { get; set; }
        public CurrencyDto Currency { get; set; }

    }
}
