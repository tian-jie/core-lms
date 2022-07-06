using CoreLMS.Core.Interfaces;
using System;

namespace CoreLMS.Core.Entities
{
    public class CourseLessonAttachment : IAuditableEntity, IEntity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }        
        
        public int CourseLessonId { get; set; }
        public CourseLesson CourseLesson { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
