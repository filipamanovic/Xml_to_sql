using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
