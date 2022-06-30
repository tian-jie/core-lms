using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;

namespace CoreLMS.Application.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        public CourseService(IAppDbContext unitOfWork)
            : base(unitOfWork)
        {
        }

    }
}
