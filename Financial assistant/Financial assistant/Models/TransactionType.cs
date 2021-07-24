﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Financial_assistant.Models
{
    public class TransactionType
    {
        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public bool Private { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
