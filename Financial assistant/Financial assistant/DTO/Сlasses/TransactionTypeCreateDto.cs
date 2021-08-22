using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.DTO.Сlasses
{
    public class TransactionTypeCreateDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public bool Private { get; set; }
        public int? UserId { get; set; }
    }
}
