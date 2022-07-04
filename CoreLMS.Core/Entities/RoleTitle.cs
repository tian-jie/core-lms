using CoreLMS.Core.Interfaces;
using System;

namespace CoreLMS.Core.Entities
{
    public class RoleTitle : IAuditableEntity, IEntity
    {
        public RoleTitle()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int Rate { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }




    }
}
