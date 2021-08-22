using Financial_assistant.DTO.Contracts;

namespace Financial_assistant.DTO.Сlasses
{
    public class TransactionTypeDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool Private { get; set; }
        public int? UserId { get; set; }
    }
}
