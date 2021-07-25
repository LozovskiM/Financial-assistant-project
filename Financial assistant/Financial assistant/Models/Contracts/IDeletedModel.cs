using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Models.Contracts
{
    public interface IDeletedModel
    {
        bool IsDeleted { get; set; }
    }
}
