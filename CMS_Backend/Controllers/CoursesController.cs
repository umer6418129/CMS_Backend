using CMS_Backend.Helpers;
using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
                            displayImage = db.FileRepos.Where(p => p.tbl_name == FileDirectoryHelper.course && p.rowId == c.id).Select(p => p.file_name).FirstOrDefault(),
                            ReviewsCount = db.Feedbacks.Where(x => x.courseId == c.id).Count(),
                            stdCount = db.StudentInfos.Where(x => x.course_id == c.id).Count(),
                            category = db.CourseCategories.Where(x => x.id == c.category_id).Select(category => category.name).FirstOrDefault(),
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
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var course = db.Courses.Select(c => new
            {
                id = c.id,
                course_name = c.course_name,
                description = c.description,
                is_available = c.is_available,
                duaration = c.course_duration,
                no_of_classess = c.no_of_classes,
                displayImage = db.FileRepos.Where(p => p.tbl_name == FileDirectoryHelper.course && p.rowId == c.id).Select(p => p.file_name).FirstOrDefault(),
                reviewsCount = db.Feedbacks.Where(x => x.courseId == c.id).Count(),
                reviews = db.Feedbacks.Where(x => x.courseId == c.id).ToArray(),
                stdCount = db.StudentInfos.Where(x => x.course_id == c.id).Count(),
                category = db.CourseCategories.Where(x => x.id == c.category_id).Select(category => category.name).FirstOrDefault(),
                faculty = db.CourseFaculties.Select(fc => new
                {
                    id = fc.faculty_id,
                    faculty_info = db.FacultyInfos.Where(x => x.user_id == fc.faculty_id).Select(info => new
                    {
                        type = info.facultyType.name,
                    }).FirstOrDefault(),
                    name = fc.user.name,
                    profile = db.FileRepos.Where(p => p.tbl_name == FileDirectoryHelper.facultyProfile && p.rowId == fc.faculty_id).Select(p => p.file_name).FirstOrDefault(),
                }).ToArray(),
                subjects = c.CourseSubjects.Select(cs => new
                {
                    id = cs.subjects.id,
                    name = cs.subjects.name,
                }).ToArray()
            }).FirstOrDefault(x => x.id == id);
            return Ok(new
            {
                status = 1,
                data = course
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
            if (request.course_image == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Image is Required"
                });
            }
            var course = new Course
            {
                course_name = request.course_name,
                description = request.description,
                category_id = request.category_id,
                course_duration = request.course_duration,
                no_of_classes = request.no_of_classes,
                is_available = request.is_available == true ? true : false,
                is_featured = false,

            };
            db.Courses.Add(course);
            db.SaveChanges();

            foreach (var item in request.subject_ids)
            {
                var subject = db.Subjects.FirstOrDefault(x => x.id == item);
                if (subject != null)
                {
                    var courseSubjectIds = new CourseSubjects
                    {
                        course_id = course.id,
                        subject_id = item
                    };
                    db.CourseSubjects.Add(courseSubjectIds);
                }
            }
            foreach (var item in request.faculties_id)
            {
                var subject = db.Users.FirstOrDefault(x => x.id == item);
                if (subject != null)
                {
                    var courseFacultyIds = new CourseFaculties
                    {
                        faculty_id = item,
                        course_id = course.id,
                    };
                    db.CourseFaculties.Add(courseFacultyIds);
                }
            }
            db.SaveChanges();
            FileManagerHelper.Upload(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "files"), FileDirectoryHelper.course, request.course_image, course.id, db);
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
            courseToUpdate.is_available = request.is_available == true ? true : false;
            courseToUpdate.description = request.description;
            courseToUpdate.category_id = request.category_id;
            courseToUpdate.no_of_classes = request.no_of_classes;
            courseToUpdate.course_duration = request.course_duration;



            // Remove existing CourseSubjects for the course
            var existingCourseSubjects = db.CourseSubjects.Where(cs => cs.course_id == request.id);
            db.CourseSubjects.RemoveRange(existingCourseSubjects);

            // Add new CourseSubjects for the course
            foreach (var item in request.subject_ids)
            {
                var subject = db.Subjects.FirstOrDefault(x => x.id == item);
                if (subject != null)
                {
                    var courseSubject = new CourseSubjects
                    {
                        course_id = request.id,
                        subject_id = item
                    };
                    db.CourseSubjects.Add(courseSubject);
                }
            }

            foreach (var item in request.faculties_id)
            {
                var subject = db.Users.FirstOrDefault(x => x.id == item);
                if (subject != null)
                {
                    var courseFacultyIds = new CourseFaculties
                    {
                        faculty_id = item,
                        course_id = request.id,
                    };
                    db.CourseFaculties.Add(courseFacultyIds);
                }
            }

            db.SaveChanges();

            if (request.course_image != null)
            {
                FileManagerHelper.Update(Path.Combine(Directory.GetCurrentDirectory(), "Resources", "files"), FileDirectoryHelper.course, request.course_image, courseToUpdate.id, db);
            }

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
            else if (string.IsNullOrEmpty(Convert.ToString(request.category_id)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Course Category is Required"
                });
            }
            else if (string.IsNullOrEmpty(request.description))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Description is Required"
                });
            }
            else if (string.IsNullOrEmpty(request.course_duration))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Image is Required"
                });
            }
            else if (request.subject_ids.Length < 1)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Atleast 1 subject is required"
                });
            }
            else if (request.faculties_id.Length < 1)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Atleast 1 faculty is required"
                });
            }

            return null;
        }

        [HttpGet("featured")]
        public IActionResult isFeatured()
        {
            try
            {
                var courses = db.Courses.Where(x => x.is_featured == true)
                        .OrderByDescending(x => x.id)
                        .Select(c => new
                        {
                            id = c.id,
                            course_name = c.course_name,
                            description = c.description,
                            is_available = c.is_available,
                            displayImage = db.FileRepos.Where(p => p.tbl_name == FileDirectoryHelper.course && p.rowId == c.id).Select(p => p.file_name).FirstOrDefault(),
                            ReviewsCount = db.Feedbacks.Where(x => x.courseId == c.id).Count(),
                            stdCount = db.StudentInfos.Where(x => x.course_id == c.id).Count(),
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

        [HttpPost("featured")]
        public IActionResult toogleFeatured(FeaturedCourseRequest featuredCourseRequest)
        {
            var course = db.Courses.FirstOrDefault(x => x.id == featuredCourseRequest.id);
            if (course == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "Course not found",
                });
            }

            if (featuredCourseRequest.is_featured == false)
            {
                var courseCount = db.Courses.Where(x => x.is_featured == false).Count();
                if (courseCount < 3)
                {
                    return Ok(new
                    {
                        status = 0,
                        message = "Atleast 3 courses should be featured",
                    });
                }
            }

            course.is_featured = featuredCourseRequest.is_featured;
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Course featured successfully"
            });

        }
    }
}
