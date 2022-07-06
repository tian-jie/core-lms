using System;

namespace CoreLMS.Core.Entities
{
    public class AuthorCourseLesson : IEntity
    {
        public int Id { get; set; } 
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CourseLessonId { get; set; }
        public CourseLesson CourseLesson { get; set; }
    }
}
