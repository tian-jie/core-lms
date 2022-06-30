using CoreLMS.Core.DataTransferObjects;
using CoreLMS.Core.Entities;
using CoreLMS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CoreLMS.Web.Areas.Admin.Pages.Courses
{
    public class DeleteModel : PageModel
    {
        private readonly ICourseService courseService;

        public DeleteModel(ICourseService courseService)
        {            
            this.courseService = courseService;
        }

        [BindProperty]
        public UpdateCourseDto CourseDto { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Course course = await courseService.GetByIdAsync(id.Value);

            if (course == null)
            {
                return NotFound();
            }

            CourseDto = new UpdateCourseDto
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                CourseType = course.CourseType,
                CourseImageURL = course.CourseImageURL
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (CourseDto == null)
            {
                return NotFound();
            }

            await courseService.DeleteByIdAsync(CourseDto.Id);

            return RedirectToPage("./Index");
        }
    }
}
