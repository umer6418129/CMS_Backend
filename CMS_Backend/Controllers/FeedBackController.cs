﻿using CMS_Backend.Models;
using CMS_Backend.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        public MyContext db { get; set; }
        public FeedBackController(MyContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var feedback = db.Feedbacks.OrderByDescending(x => x.id).ToArray();
                return Ok(new
                {
                    status = 1,
                    data = feedback,
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]

        public IActionResult createFeedback(FeedBackRequest request)
        {
            IActionResult validationResponse = validation(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }
            var course = db.Courses.Where(x => x.id == request.courseId).FirstOrDefault();
            if (course == null)
            {
                return Ok(new
                {
                    status = 0,
                    message = "course not found"
                });
            }
            var feedback = new StudentFeedback
            {
                courseId = request.courseId,
                std_id = request.std_id,
                description = request.description,
            };
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return Ok(new
            {
                status = 1,
                message = "Feedback added successfully"
            });
        }

        [HttpDelete]
        public IActionResult deleteFeedback(int id)
        {
            try
            {
                var feedback = db.Feedbacks.FirstOrDefault(x => x.id == id);
                if (feedback == null)
                {
                    return Ok(new
                    {
                        status = 0,
                        message = "feedback not found",
                    });
                }
                db.Feedbacks.Remove(feedback);
                db.SaveChanges();
                return Ok(new
                {
                    status = 1,
                    message = "feedback has deleted",
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IActionResult validation(FeedBackRequest request)
        {
            var user = db.Users.FirstOrDefault(x => x.id == request.std_id);
            if (user != null)
            {
                var student = db.StudentInfos.FirstOrDefault(x => x.user_id == request.std_id);
                if (student == null)
                {
                    return Ok(new
                    {
                        status = 0,
                        message = "Student not found"
                    });
                }
            }
            else
            {
                return Ok(new
                {
                    status = 0,
                    message = "Student not found"
                });

            }
            if (string.IsNullOrEmpty(Convert.ToString(request.std_id)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "Student is Required"
                });
            }
            else if (string.IsNullOrEmpty(request.description))
            {
                return Ok(new
                {
                    status = 0,
                    message = "description is Required"
                });

            }
            else if (string.IsNullOrEmpty(Convert.ToString(request.courseId)))
            {
                return Ok(new
                {
                    status = 0,
                    message = "courseId is Required"
                });

            }
            return null;
        }
    }
}
