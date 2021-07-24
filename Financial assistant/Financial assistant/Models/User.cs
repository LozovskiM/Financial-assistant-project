using System;
using System.Collections.Generic;

#nullable disable

namespace Financial_assistant.Models
{
    public class User
    {
        public User()
        {
            BankAccounts = new HashSet<BankAccount>();
            TransactionTypes = new HashSet<TransactionType>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string County { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<TransactionType> TransactionTypes { get; set; }
    }
}
