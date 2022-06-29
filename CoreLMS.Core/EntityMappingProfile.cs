using AutoMapper;
using CoreLMS.Core.DataTransferObjects;
using CoreLMS.Core.Entities;

namespace CoreLMS.Core
{
    public class EntityMappingProfile : Profile
    {
        public EntityMappingProfile()
        {
            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>().ReverseMap();

            CreateMap<CreateCourseDto, Course>().ReverseMap();
            CreateMap<UpdateCourseDto, Course>().ReverseMap();

            CreateMap<CreateCourseLessonDto, CourseLesson>().ReverseMap();
        }
    }
}
