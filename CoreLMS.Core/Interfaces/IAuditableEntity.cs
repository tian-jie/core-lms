using System;

namespace CoreLMS.Core.Interfaces
{
    public interface IAuditableEntity
    {
        int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateUpdated { get; set; }
        DateTime? DateDeleted { get; set; }        
    }
}
