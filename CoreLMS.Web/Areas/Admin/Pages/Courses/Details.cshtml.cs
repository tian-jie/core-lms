using CoreLMS.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CoreLMS.Web.Areas.Admin.Pages.Courses
{
    public class DetailsModel : PageModel
    {
        private readonly ICourseService courseService;

        public DetailsModel(ICourseService courseService)
        {   
            this.courseService = courseService;
        }

        public CourseViewModel Course { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbCourse = await courseService.GetByIdAsync(id.Value);

            Course = new CourseViewModel
            {
                Id = dbCourse.Id,
                DateCreated = dbCourse.DateCreated,
                DateUpdated = dbCourse.DateUpdated,
                Name = dbCourse.Name,
                Description = dbCourse.Description,
                CourseType = dbCourse.CourseType,
                CourseImageURL = dbCourse.CourseImageURL
            };

            if (Course == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
