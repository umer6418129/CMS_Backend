using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                var courses = db.Courses
                        .OrderByDescending(x => x.id)
                        .Select(c => new
                        {
                            id = c.id,
                            course_name = c.course_name,
                            description = c.description,
                            is_available = c.is_available,
                            subjects = c.CourseSubjects
                                        .Select(cs => new
                                        {
                                            id = cs.subjects.id,
                                            name = cs.subjects.name,
                                        })
                                        .ToArray()
                        })
                        .ToArray();

                return Ok(new
                {
                    status = 1,
                    data = courses
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
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

            foreach (var item in request.subject_ids)
            {
                var subject = db.CourseSubjects.FirstOrDefault(x => x.id == item);
                if (subject != null)
                {
                    var courseSubjectIds = new CourseSubjects[]
                    {
                    new CourseSubjects {course_id = course.id,subject_id = item}
                    };
                    db.CourseSubjects.AddRange(courseSubjectIds);
                }
            }
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
                return Ok(new
                {
                    status = 0,
                    message = "Course not found",
                });
            }

            courseToUpdate.course_name = request.course_name;
            foreach (var item in request.subject_ids)
            {
                var subject = db.Subjects.FirstOrDefault(x => x.id == item);
                if (subject != null)
                {
                    var courseSubjectIds = new CourseSubjects[]
                    {
                    new CourseSubjects {course_id = request.id,subject_id = item}
                    };
                    db.CourseSubjects.AddRange(courseSubjectIds);
                }
            }
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
