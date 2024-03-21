using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        public MyContext db { get; set; }
        public CoursesController(MyContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult getCourses()
        {
            var courses = db.Courses.OrderByDescending(x => x.id).ToArray();
            return Ok(new
            {
                status = 1,
                data = courses
            });
        }

        [HttpPost]
        public IActionResult createCourse(CourseRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var course = new Course
            {
                course_name = request.course_name
            };
            db.Courses.Add(course);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Course added successfully"
            });
        }

        [HttpPut]
        public IActionResult updateCourse(CourseRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var courseToUpdate = db.Courses.FirstOrDefault(x => x.id == request.id);
            if (courseToUpdate == null)
            {
                return Ok(new{
                    status = 0,
                    message = "Course not found",
                });
            }

            courseToUpdate.course_name = request.course_name;

            db.SaveChanges();

            return Ok(new
            {
                status = 1,
                message = "Course updated successfully"
            });
        }

        private IActionResult validation(CourseRequest request)
        {
            if (string.IsNullOrEmpty(request.course_name))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Course Name is Required"
                });
            }
            return null;
        }
    }
}
