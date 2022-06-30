using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;

namespace CoreLMS.Application.Services.CourseLessonService
{
    public class CourseLessonService : BaseService<CourseLesson>, ICourseLessonService
    {
        public CourseLessonService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {
            
        }

    }
}
