using Financial_assistant.Models.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Financial_assistant.Services.BaseDbServices.Extensions
{
    public static class EntityTypeConfigurationExtensions
    {
        public static EntityTypeBuilder<T> IsSoftDelete<T>(this EntityTypeBuilder<T> builder) where T : class, IDeletedModel
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
            return builder;
        }
    }
}
