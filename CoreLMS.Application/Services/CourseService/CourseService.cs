using CoreLMS.Core.DataTransferObjects;
using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services
{
    public partial class CourseService : ICourseService
    {
        private readonly IRepository<Course> _repository;
        private readonly ILogger<CourseService> _logger;

        public CourseService(IAppDbContext unitOfWork, ILogger<CourseService> logger)
        {
            _logger = logger;
            _repository = new Repository<Course>(unitOfWork);
        }

        public async Task AddCourseAsync(CreateCourseDto courseDto)
        {
            var course = new Course
            {
                Name = courseDto.Name,
                Description = courseDto.Description,
                CourseType = courseDto.CourseType,
                CourseImageURL = courseDto.CourseImageURL
            };

            try
            {
                this.ValidateCourseOnCreate(course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Attempted to add invalid course.");
                throw;
            }

            await _repository.CreateAsync(course);
        }

        public async Task UpdateCourseAsync(UpdateCourseDto courseDto)
        {
            var course = await _repository.FindAsync(a=>a.Id == courseDto.Id);

            course.Name = courseDto.Name;
            course.Description = courseDto.Description;
            course.CourseType = courseDto.CourseType;
            course.CourseImageURL = courseDto.CourseImageURL;

            try
            {
                this.ValidateCourseOnUpdate(course);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Attempted to update invalid course.");
                throw;
            }

            await _repository.UpdateAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _repository.FindAsync(a => a.Id == id);

            if (course == null)
            {
                _logger.LogWarning($"Course {id} not found for deletion.");
                throw new ApplicationException($"Course {id} not found for deletion.");
            }

            await _repository.DeleteAsync(course);
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            var course = await _repository.FindAsync(a => a.Id == id);

            if (course == null)
            {
                _logger.LogWarning($"Course {id} not found.");
                throw new ApplicationException($"Course {id} not found.");
            }

            return course;
        }

        public async Task<List<Course>> GetCoursesAsync() => (await _repository.AllAsync()).ToList();
    }
}
